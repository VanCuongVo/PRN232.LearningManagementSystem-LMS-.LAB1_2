
using System.Diagnostics;
using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.Data;
namespace PRN232.LMS.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, LmsdbContext dbContext)
        {
            var sw = Stopwatch.StartNew();

            await _next(context);

            sw.Stop();

            var log = new ApiLog
            {
                Path = context.Request.Path,
                Method = context.Request.Method,
                StatusCode = context.Response.StatusCode,
                ExecutionTimeMs = sw.ElapsedMilliseconds,
                CreatedAt = DateTime.UtcNow
            };
            dbContext.ApiLogs.Add(log);
            await dbContext.SaveChangesAsync();
        }
    }
}