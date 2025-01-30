using CRS.Offer.Infrastructure;

namespace CRS.Offer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Add services to the container.

            services.AddControllers();

            //services.AddDataBaseContext("Npgsql",builder.Configuration.GetConnectionString("NpgsqlConnection")!);
            services.AddDataBaseContext("Sqlite", builder.Configuration.GetConnectionString("SqliteConnection")!);
            services.AddServices();
            services.AddEfRepository();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
