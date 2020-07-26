using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapi_Importacao.Domain.Entities;
using Webapi_Importacao.Domain.Interface;
using Webapi_Importacao.Infra.Data.Context;
using Webapi_Importacao.Infra.Data.Repository;
using Webapi_Importacao.Service.Services;

namespace Webapi_Importacao
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

            var connection = Configuration["ConexaoSql:SqlConnectionString"];
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection)
            );

            services.AddScoped<IService<Importacao>, ImportacaoService<Importacao>>();
            services.AddScoped<IRepository<Importacao>, BaseRepository<Importacao>>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowDev",
                 builder => builder.WithOrigins("*").AllowAnyHeader()
                    .AllowAnyMethod()
                 );
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowDev");
            }

            app.UseMvc();
        }
    }
}
