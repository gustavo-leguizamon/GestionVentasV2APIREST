using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GL.GestionVentas.Business.Mappers;
using GL.GestionVentas.Business.Services.Commands;
using GL.GestionVentas.Business.Services.Queries;
using GL.GestionVentas.Domain.Interfaces.Repositories.Commands;
using GL.GestionVentas.Domain.Interfaces.Repositories.Queries;
using GL.GestionVentas.Domain.Interfaces.Services.Commands;
using GL.GestionVentas.Domain.Interfaces.Services.Queries;
using GL.GestionVentas.Repositories.Commands;
using GL.GestionVentas.Repositories.Commands.Base;
using GL.GestionVentas.Repositories.Contexts;
using GL.GestionVentas.Repositories.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace GL.GestionVentas.API
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
            //Remove circular rerferences in json response
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GestionVentas APIs v1.0",
                    Description = "Test services"
                });
            });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<GestionVentasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(ISaleCommandRepository), typeof(SaleCommandRepository));
            services.AddScoped(typeof(ISaleCommandService), typeof(SaleCommandService));
            services.AddScoped(typeof(ISaleQueryRepository), typeof(SaleQueryRepository));
            services.AddScoped(typeof(ISaleQueryService), typeof(SaleQueryService));
            services.AddScoped(typeof(IClientCommandRepository), typeof(ClientCommandRepository));
            services.AddScoped(typeof(IClientCommandService), typeof(ClientCommandService));
            services.AddScoped(typeof(IClientQueryRepository), typeof(ClientQueryRepository));
            services.AddScoped(typeof(IClientQueryService), typeof(ClientQueryService));
            services.AddScoped(typeof(IProductCommandRepository), typeof(ProductCommandRepository));
            services.AddScoped(typeof(IProductCommandService), typeof(ProductCommandService));

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GestionVentas APIs v1.0");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
