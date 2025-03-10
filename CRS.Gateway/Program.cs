using CRS.Gateway.Middleware;
using RouteParams = CRS.Gateway.Configuration.RouteParams;


namespace CRS.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        
            //builder.Configuration.AddEnvironmentVariables();
            
            builder.Configuration.AddJsonFile("gateway.json");
            
            //builder.Services.AddHttpsRedirection(opt => opt.HttpsPort = 5081);

            var app = builder.Build();

            //if (app.Environment.IsDevelopment()) {}

            //app.UseHttpsRedirection();

            app.UseGateway(app.Configuration.GetSection("Routes").Get<List<RouteParams>>());

            app.MapGet("/", HandleStaticPage );

            app.Run();

            async Task HandleStaticPage(HttpContext context)
            {
                var htmlContent = @"Hello from gateway!";
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync(htmlContent);
            }
        }
    }
}


/*
+ context.Request.Method-GET
context.Request.Scheme-HTTP
context.Request.Host-localhost:port
+ context.Request.Path-/
 */