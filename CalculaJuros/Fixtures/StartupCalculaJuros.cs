using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
using JurosAPI.Business.Repositories;
using JurosAPI.Business.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Fixtures
{
    public class StartupCalculaJuros
    {
        public IConfiguration Configuration { get; }

        public StartupCalculaJuros(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
