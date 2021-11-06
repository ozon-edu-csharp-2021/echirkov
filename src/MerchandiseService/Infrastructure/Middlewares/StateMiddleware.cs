using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class StateMiddleware
    {
        public StateMiddleware(RequestDelegate next)
        { }
        
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}