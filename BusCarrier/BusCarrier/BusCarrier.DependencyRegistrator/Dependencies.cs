using System;
using BusCarrier.BLL.Interfaces;
using BusCarrier.BLL.Services;
using BusCarrier.DAL.Interfaces;
using BusCarrier.DAL.Repositories;
using BusCarrier.Util.Config;
using BusCarrier.Util.Helpers;
using Microsoft.AspNetCore.Identity;
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

            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<IMessageService, MessageService>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.MaxFailedAccessAttempts = 3;
            });

        }
    }
}
