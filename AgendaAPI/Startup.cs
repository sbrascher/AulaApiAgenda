using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Repositorio;
using AgendaAPI.Servico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AgendaAPI
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
            services.AddDbContext<AgendaContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            // Repositorios
            services.AddTransient<IContatoRepositorio, ContatoRepositorio>();
            services.AddTransient<ITelefoneRepositorio, TelefoneRepositorio>();
            
            // Servicos
            services.AddTransient<IContatoServico, ContatoServico>();
            services.AddTransient<ITelefoneServico, TelefoneServico>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
