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
            
            var builder = new StringBuilder(Environment.NewLine);
          
            builder.Append($"Request route: {request.Path}");

            if (request.Headers.Any())
                builder.AppendLine("Request headers:");
            foreach (var header in request.Headers)
            {
                builder.AppendLine($"{header.Key}:{header.Value}");
            }

            _logger.LogInformation(builder.ToString());
        }

        private void LogResponseInformation(HttpResponse response)
        {
            if (response.ContentLength == 0)
                return;

            var builder = new StringBuilder(Environment.NewLine);

            if (response.Headers.Any())
                builder.AppendLine("Request headers:");
            foreach (var header in response.Headers)
            {
                builder.AppendLine($"{header.Key}:{header.Value}");
            }

            _logger.LogInformation(builder.ToString());
        }
    }
}