using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusCarrier.WPFClient.ViewModels;
using BusCarrier.WPFClientBLL.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BusCarrier.WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WebApisModel>(sp => new WebApisModel
            {
                WebApi = ConfigurationManager.AppSettings["WebApi"].ToString()
            });
           
            services.AddScoped<RoutesViewModel>();
            services.AddScoped<StationViewModel>();
            services.AddScoped<DashboardViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddScoped<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var locator = (ViewModelLocator)Current.Resources["Locator"];
            locator.SetUp(host.Services.GetRequiredService<MainViewModel>());
        }

        protected override void OnExit(ExitEventArgs e)
        {
            host.Dispose();
        }
    }
}
