using System;
using System.Collections.Generic;
using System.Text;
using AuthServer.BLL.Interfaces;
using AuthServer.BLL.Services;
using AuthServer.Util.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServer.DependencyRegistrator
{
    public class Dependencies
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IMailSender, MailSender>();
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
