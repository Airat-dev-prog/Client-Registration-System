using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;


namespace CRS.Gateway
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole();

            //string? pathValue = Environment.GetEnvironmentVariable("DOWNSTREAM_HOST")
            //    + ", " + Environment.GetEnvironmentVariable("DOWNSTREAM_HTTP_PORT")
            //    + ", " + Environment.GetEnvironmentVariable("DOWNSTREAM_HTTPS_PORT")
            //    + ", " + Environment.GetEnvironmentVariable("GATEWAY_BASE_URL");

            //Console.WriteLine($"{pathValue ?? "Не найден"}");

            builder.Configuration.AddEnvironmentVariables();
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                builder.Configuration.AddJsonFile("ocelot.Development.json");
            else
                builder.Configuration.AddJsonFile("ocelot.json");

            builder.Services.AddOcelot(builder.Configuration);
            //builder.Services.AddHttpsRedirection(opt => opt.HttpsPort = 5081);

            var app = builder.Build();
            //if (app.Environment.IsDevelopment()) {}
            //app.UseHttpsRedirection();

            app.UseOcelot().Wait();

            Console.WriteLine("Hello from ocelot!!!!!");
            app.MapGet("/", () => "Hello from ocelot!");

            //app.MapGet("/", () => pathValue );

            app.Run();
        }
    }
}