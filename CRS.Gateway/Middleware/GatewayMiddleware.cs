using CRS.Gateway.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using RouteParams = CRS.Gateway.Configuration.RouteParams;

namespace CRS.Gateway.Middleware
{
    public class GatewayMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<RouteParams> _routeParamsList;

        public GatewayMiddleware(RequestDelegate next, IEnumerable<RouteParams> routeParamsList)
        {
            _next = next;
            _routeParamsList = routeParamsList;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            var _routeParams = GetRouteParams(context);

            if (_routeParams != null)
            {
                await RedirectRequest(context, _routeParams);
                return;
            }

            await _next(context);
        }

        private RouteParams? GetRouteParams(HttpContext context)
        {
            var _path = context.Request.Path;
            var _method = context.Request.Method;
            var _scheme = context.Request.Scheme;

            return _routeParamsList.FirstOrDefault(route => route.UpstreamPathTemplate.ToLower() == _path.ToString().ToLower() &&
            route.UpstreamHttpMethods.Exists(method => method.ToUpper() == _method.ToUpper()) &&
            route.UpstreamSchemes.Exists(scheme => scheme.ToLower() == _scheme.ToLower()));
        }

        private async Task RedirectRequest(HttpContext context, RouteParams _routeParams)
        {
            var newRequest = CreateNewRequest(context, new Uri($"{_routeParams.DownstreamScheme}://{_routeParams.DownstreamHostAndPorts}{_routeParams.DownstreamPathTemplate}"));

            var handler = GetHandler(GetCert());

            var client = CreateClient(_routeParams.DownstreamScheme.ToLower(), handler);

            var response = await client.SendAsync(newRequest);

            await FillСontext(context, response);
        }

        private async Task FillСontext(HttpContext context, HttpResponseMessage response) 
        {
            context.Response.StatusCode = (int)response.StatusCode;

            //Зависает браузер 
            //foreach (var header in response.Headers)
            //{
            //    context.Response.Headers[header.Key] = header.Value.ToArray();
            //}

            foreach (var header in response.Content.Headers)
            {
                context.Response.Headers[header.Key] = header.Value.ToArray();
            }
            await response.Content.CopyToAsync(context.Response.Body);
        }


        private HttpRequestMessage CreateNewRequest(HttpContext context, Uri _uri)
        {
            var newRequest = new HttpRequestMessage(new HttpMethod(context.Request.Method), _uri);

            if (context.Request.Body.CanRead)
            {
                newRequest.Content = new StreamContent(context.Request.Body);
            }

            foreach (var header in context.Request.Headers)
            {
                if (!newRequest.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()) &&
                    newRequest.Content != null)
                {
                    newRequest.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                }
            }

            return newRequest;
        }

        private X509Certificate2? GetCert()
        {
            string? certPath = Environment.GetEnvironmentVariable("Cert_Centrum_Path");
            string? certPassword = Environment.GetEnvironmentVariable("Cert_Centrum_Password");

            //certPath = Environment.GetEnvironmentVariable("APPDATA") + "\\ASP.NET\\Https\\CRS.Centrum.pfx";
            //certPassword = "Centrum";

            if (certPath != null)
                return new X509Certificate2(certPath, certPassword);

            return null;
        }

        private HttpClientHandler GetHandler(X509Certificate2? _cert)
        {
            var handler = new HttpClientHandler();
            
            if (_cert != null)
                handler.ClientCertificates.Add(_cert);

            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            return handler;
        }

        private HttpClient CreateClient(string _method, HttpClientHandler _handler)
        {
            return _method == "https" ? new HttpClient(_handler) : new HttpClient();
        }

    }

    public static class GatewayMiddlewareExtensions
    {
        public static IApplicationBuilder UseGateway(this IApplicationBuilder builder, IEnumerable<RouteParams>? routes)
        {
            return builder.UseMiddleware<GatewayMiddleware>(routes);
        }
    }


}
