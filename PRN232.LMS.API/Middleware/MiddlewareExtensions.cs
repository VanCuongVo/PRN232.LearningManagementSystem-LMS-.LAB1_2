
namespace PRN232.LMS.API.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(
        this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }

    }
}