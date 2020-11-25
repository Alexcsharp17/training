using BusCarrier.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BusCarrier.DependencyRegistrator
{
    public class DbContextRegistrator
    {
        public static void AddDbContext(IServiceCollection services, string connection)
        {
            services.AddScoped<DbContext, ApplicationContext>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connection));
        }
    }
}
