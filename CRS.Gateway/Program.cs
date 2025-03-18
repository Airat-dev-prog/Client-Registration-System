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


            if (builder.Environment.IsDevelopment())
                builder.Configuration.AddJsonFile("gateway.Development.json");
            else
                builder.Configuration.AddJsonFile("gateway.json");


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")   // AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            //builder.Services.AddHttpsRedirection(opt => opt.HttpsPort = 5081);

            var app = builder.Build();

            app.UseRouting();
            app.UseCors("AllowAll");

            //if (app.Environment.IsDevelopment()) {}

            //app.UseHttpsRedirection();

            app.UseGateway(app.Configuration.GetSection("Routes").Get<List<RouteParams>>());

            app.MapGet("/", HandleStaticPage);

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