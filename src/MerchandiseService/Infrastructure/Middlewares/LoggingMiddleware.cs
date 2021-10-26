using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequestInformation(context.Request);
            await _next(context);
            LogResponseInformation(context.Response);
        }

        private void LogRequestInformation(HttpRequest request)
        {
            if (request.ContentLength == 0)
                return;

            _logger.LogInformation($"Request route: {request.Path}");

            LogHeaders(request.Headers);
        }
        
        private void LogResponseInformation(HttpResponse response)
        {
            if (response.ContentLength == 0)
                return;

            LogHeaders(response.Headers);
        }

        private void LogHeaders(IHeaderDictionary headers)
        {
            var builder = new StringBuilder();

            if (headers.Any())
                builder.AppendLine("Headers:");
            foreach (var (key, value) in headers)
            {
                builder.AppendLine($"{key}:{value}");
            }

            _logger.LogInformation(builder.ToString());
        }
    }
}