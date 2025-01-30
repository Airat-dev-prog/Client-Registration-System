using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Infrastructure.Data;
using CRS.Offer.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRS.Offer.Application.Services;

namespace CRS.Offer.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDataBaseContext(this IServiceCollection services,string DBType, string connectionString)
        {
            switch (DBType) 
            {
                case "Npgsql": 
                    services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(connectionString));
                    break;
                case "Sqlite":
                    services.AddDbContext<DataBaseContext>(options => options.UseSqlite(connectionString));
                    break;
            }
        }

        public static void AddEfRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(OfficeSrv));
            services.AddScoped(typeof(MasterSrv));
            services.AddScoped(typeof(ServiceSrv));
            services.AddScoped(typeof(ScheduleSrv));
        }
    }
}
