using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Product.API.Middlewares
{
    // If the request takes more than 500 ms, a performance log is kept.
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        //While the project is running. You can see the log by selecting the
        //"Product.API-ASP.NET Web Server" option from the "show output from" section.
        public async Task Invoke(HttpContext httpContext)
        {

            var watch = Stopwatch.StartNew();

            await _next.Invoke(httpContext);
            watch.Stop();
            if (watch.ElapsedMilliseconds > 500)
            {
                _logger.LogTrace("Duration:{duration}ms, Request path:{path},Request Method:{method}",
                    watch.ElapsedMilliseconds, httpContext.Request.Path, httpContext.Request.Method);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
