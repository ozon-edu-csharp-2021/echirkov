using System;
using System.IO;
using System.Reflection;
using MerchandiseService.Infrastructure.Filters;
using MerchandiseService.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddMvc();
                
                services.AddSingleton<IStartupFilter, InfrastructureStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "MerchandiseService", Version = "v1"});
                
                    var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);
                    options.CustomSchemaIds(x => x.FullName);
                });
            });
            return builder;
        }
    }
}