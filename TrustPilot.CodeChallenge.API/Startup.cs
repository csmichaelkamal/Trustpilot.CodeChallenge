using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TrustPilot.CodeChallenge.API.Extensions;
using TrustPilot.CodeChallenge.Services;
using TrustPilot.CodeChallenge.Services.Interfaces;

namespace TrustPilot.CodeChallenge.API
{
    /// <summary>
    /// Startup class for configuring the Services and the Request Pipeline
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor of the Startup class
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration for the application from variant sources
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure the Services in the .Net Core DI container
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpContextAccessor();

            services.AddHttpClient("maze", options =>
            {
                options.BaseAddress = new Uri(Configuration["Maze:BaseUrl"]);
                options.Timeout = TimeSpan.FromSeconds(10);
            });

            // In case of multiple service, it's better to add extension methods in a separate class
            services.AddScoped<IMazeManager, MazeManager>();

            services.AddSwaggerGen();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        /// <summary>
        /// Configure the Asp.Net Core Request Pipeline, the order matters
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseGlobalExceptionHandling();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pony Maze V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
