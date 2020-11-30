using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusCarrier.DAL.Data;
using BusCarrier.DependencyRegistrator;
using BusCarrier.Util.Config;
using BusCarrier.WEBAPI.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BusCarrier.WEBAPI
{
    public class Startup
    {
        private const string GMAIL = "Gmail";
        private const string SelfOriginUrl = "https://localhost:44304";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            DbContextRegistrator.AddDbContext(services, connection);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = SelfOriginUrl;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        // sets nessesety of issuer validation
                        ValidateIssuer = true,

                        // string sets valid issuer
                        ValidIssuer = AuthOptions.ISSUER,

                        // sets nessesety of token audience validation
                        ValidateAudience = true,

                        // sets valid audience
                        ValidAudience = AuthOptions.AUDIENCE,

                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // sets security key
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // sets nesseseti of security key validation
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddAuthorization();
            services.Configure<EmailConfig>(options =>
                Configuration.GetSection(GMAIL).Bind(options));
            
            Dependencies.InjectDependencies(services, Configuration);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
