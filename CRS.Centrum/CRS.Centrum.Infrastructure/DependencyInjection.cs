using CRS.Centrum.Core.Repositories.Base;
using CRS.Centrum.Infrastructure.Data;
using CRS.Centrum.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CRS.Centrum.Application.Services;

namespace CRS.Centrum.Infrastructure
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
