using AuthServer.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AuthServer.DependencyRegistrator
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
