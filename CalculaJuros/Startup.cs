using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
using JurosAPI.Business.Repositories;
using JurosAPI.Business.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CalculaJuros
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
            //Options
            services.Configure<UrlAPIConfig>(Configuration.GetSection("UrlAPI"));
            services.Configure<MinhaAPIConfig>(Configuration.GetSection("MinhaAPI"));

            //Add applicarion services
            services.AddTransient<ICalculaJurosService, CalculaJurosService>();
            services.AddTransient<IJurosRepository, JurosRepository>();
            services.AddTransient<IMinhaAPIService, MinhaAPIService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
