using CRS.Centrum.Infrastructure;
using Microsoft.AspNetCore.HttpLogging;

namespace CRS.Centrum.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Add services to the container.
            services.AddControllers();

            services.AddDataBaseContext("Npgsql",builder.Configuration.GetConnectionString("NpgsqlConnection")!);
            services.AddServices();
            services.AddEfRepository();

            //services.AddHttpsRedirection(opt => opt.HttpsPort = 5091);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();


            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();                
            }

            app.UseForwardedHeaders();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/test", () => "Test!!!");
            app.Run();
        }
    }
}
