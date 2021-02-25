using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CompanyEmployees.Extensions;

namespace CompanyEmployees
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Configure Nlog with nlog.config
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Added CORS and IIS configuration to the ConfigurationServices method
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            // Add LoggerService inside .NET
            // AddScoped (ILoggerManager from Contracts and LoggerManager from LoggerService)
            // Every time we want to use a logger service, all we need to do is to inject it into constructor of the class that needs it.
            // Dependency Injection
            services.ConfigureLoggerService();

            // IoC (Inversion of Control)
            services.ConfigureSqlContext(Configuration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Order of adding different middlewares to the application builder is very important.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enables using static files for request. If we don't set path to the static files directory
            // it will use a wwwroot folder in our project by default
            app.UseStaticFiles();

            // Added CORS to application's pipeline
            app.UseCors("CorsPolicy");

            // will forward proxy headers to the current request
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
