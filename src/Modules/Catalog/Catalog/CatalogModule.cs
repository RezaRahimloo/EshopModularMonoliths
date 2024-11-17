using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {

            // Add services the contianer
            /*builder.Services
                .AddApplicationServices()
                .AddInfrastructureServices(configuration)
                .AddApiServices(configuration);*/
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline
            // app
            //  .UseApplicationServices();
            //  .UseInfrastructureServices();
            //  .UseApiServices();

            return app;
        }
    }
}
