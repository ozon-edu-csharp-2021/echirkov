using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        { }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var serviceInfo = new
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version",
                ServiceName = Assembly.GetExecutingAssembly().GetName().Name
            };

            await context.Response.WriteAsync(serviceInfo.ToString());
        }
    }
}