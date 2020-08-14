using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TesteCandidatoCEP.Business.Classes;
using TesteCandidatoCEP.Business.Helpers;
using TesteCandidatoCEP.Business.Interfaces;
using TesteCandidatoCEP.Repository;
using TesteCandidatoCEP.Repository.Classes;
using TesteCandidatoCEP.Repository.Generic;
using TesteCandidatoCEP.Repository.Interfaces;

namespace TesteCandidatoCEP.WebApi
{
    public class Startup
    {
        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        */

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // para configuração do CORS, senão o frontend não conseguirá acessar a url do backend devio ao erro 'Access-Control-Allow-Origin'
        readonly string TesteCandidatoCORS = "_testeCandidatoCORS";

        public void ConfigureServices(IServiceCollection services)
        {
            // configurando contexto para MSSQL
            var connection = Configuration.GetConnectionString("EnderecoConnection");
            services.AddDbContext<TesteCandidatoCEPContext>(x => x.UseSqlServer(connection));

            #region inicio_relacao_escopos_para_injecao_dependencia

            // repositorio generico para todas as entidades
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // cada entidade tem seu próprio repositório para armazenar ações especificas para cada um.
            // O CRUD é comum para todas as entidades (IGenericRepository)
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoBusiness, EnderecoBusiness>();

            // serviço automapper
            services.AddAutoMapper(new Type[] { typeof(AutoMapperProfiles) });

            #endregion

            // Confirura o CORS
            services.AddCors(options =>
            {
                options.AddPolicy(TesteCandidatoCORS, c =>
                {
                    c.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });

            });

            services.AddMvc(o => {
                // elimina o comportamento http code status 204 para valores nulos.
                o.OutputFormatters.RemoveType(typeof(HttpNoContentOutputFormatter));
                o.OutputFormatters.Insert(0, new HttpNoContentOutputFormatter
                {
                    TreatNullValueAsNoContent = false
                });
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            // app.UseHttpsRedirection();

            // app.UseRouting();

            // app.UseAuthorization();

            app.UseCors(TesteCandidatoCORS);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=values}/{id?}");
            });
        }
    }
}
