using BusCarrier.BLL.Interfaces;
using BusCarrier.BLL.Services;
using BusCarrier.DAL.Interfaces;
using BusCarrier.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BusCarrier.DependencyRegistrator
{
    public class Dependencies
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteTemplateRepository, RouteTemplateRepository>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IStationService, StationService>();
        }
    }
}
