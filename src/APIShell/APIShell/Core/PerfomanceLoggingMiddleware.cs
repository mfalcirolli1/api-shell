using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace APIShell.Core
{
    public class PerfomanceLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PerfomanceLoggingMiddleware> _logger;
        private static readonly ConcurrentDictionary<string, (long totalTime, int requestCount)> _routeStats = new ConcurrentDictionary<string, (long, int)>();

        public PerfomanceLoggingMiddleware(RequestDelegate next, ILogger<PerfomanceLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            // Let the request proceed through the pipeline
            await _next(context);

            stopwatch.Stop();

            var routePath = context.Request.Path.Value;

            // Calculate average time taken for this route
            _routeStats.AddOrUpdate(routePath!, (stopwatch.ElapsedMilliseconds, 1), (_, data) =>
            {
                var (totalTime, requestCount) = data;
                return (totalTime + stopwatch.ElapsedMilliseconds, requestCount + 1);
            });

            // var (averageTime, requestCount) = _routeStats[route!];

            if (context.Response.StatusCode == 200)
            {
                var (averageTime, requestCount) = _routeStats[routePath!];

                var logData = $"Route: {routePath}, Time: {stopwatch.ElapsedMilliseconds}ms Average Time: {averageTime / requestCount}ms, Total Requests: {requestCount}";

                Log.Information(logData);
            }
        }
    }

    public static class PerfomanceLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder PerfomanceLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PerfomanceLoggingMiddleware>();
        }
    }
}
