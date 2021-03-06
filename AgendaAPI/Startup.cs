﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaAPI.Dominio.Repositorios;
using AgendaAPI.Dominio.Servicos;
using AgendaAPI.Extensions;
using AgendaAPI.Repositorio;
using AgendaAPI.Repositorio.Transacao;
using AgendaAPI.Servico;
using AgendaAPI.Servico.Interfaces;
using AgendaAPI.Servico.Seguranca;
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

            services.AddScoped<SigningConfigurations, SigningConfigurations>();

            // Repositorios
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IContatoRepositorio, ContatoRepositorio>();
            services.AddTransient<ITelefoneRepositorio, TelefoneRepositorio>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();

            // Servicos
            services.AddTransient<IContatoServico, ContatoServico>();
            services.AddTransient<ITelefoneServico, TelefoneServico>();
            services.AddTransient<IUsuarioServico, UsuarioServico>();
            services.AddTransient<ICriptografiaServico, CriptografiaServico>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddJwtSecurity(signingConfigurations, tokenConfigurations);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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
