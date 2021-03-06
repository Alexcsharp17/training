using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CarStore.DAL;
using CarStore.DAL.Services;
using CarStore.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CarStore.DAL.Util;
using System.Data.Common;
using FluentValidation.AspNetCore;
using CarStore.DAL.Repositories;
using CarStore.DAL.Entities;
using CarStore.DAL.Procedures;

namespace CarStore.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMapper<Person>), typeof(PersonMapper));
            services.AddScoped(typeof(IMapper<Order>), typeof(OrderMapper));
            services.AddScoped<ICommandBuilder, SqlCommandBuild>();
            services.AddScoped(typeof(IProceduresNames<Order>), typeof(OrderProceduresNames));
            services.AddScoped(typeof(IProceduresNames<Person>), typeof(PersonProceduresNames));
            services.AddScoped<DbConnection>(sp => new SqlConnection(connection));
            services.AddMvc().AddFluentValidation(mvcConfig=>mvcConfig.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Order}/{action=GetOrder}/{id?}");
            });
        }
    }
}
