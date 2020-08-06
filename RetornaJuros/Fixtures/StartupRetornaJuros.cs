using JurosAPI.Business.Interface;
using JurosAPI.Business.Model.Config;
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

namespace RetornaJuros.Fixtures
{
    public class StartupRetornaJuros
    {
        public IConfiguration Configuration { get; }

        public StartupRetornaJuros(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Options
            services.Configure<JurosConfig>(Configuration.GetSection("Juros"));

            //Add applicarion services
            services.AddTransient<IRetornaJurosService, RetornaJurosService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
