using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<object>
                {
                    success = false,
                    message = "Request failed",
                    Errors = ex.InnerException?.Message
                 ?? ex.Message
                };

                context.Response.StatusCode = 500;

                var accept = context.Request.Headers.Accept.ToString();

                if (accept.Contains("application/xml"))
                {
                    context.Response.ContentType = "application/xml";

                    var serializer =
                        new XmlSerializer(typeof(ApiResponse<object>));

                    using var stringWriter = new StringWriter();

                    serializer.Serialize(stringWriter, response);

                    await context.Response.WriteAsync(
                        stringWriter.ToString(),
                        Encoding.UTF8);
                }
                else
                {
                    context.Response.ContentType =
                        "application/json";

                    var json = JsonSerializer.Serialize(response);

                    await context.Response.WriteAsync(json);
                }
            }
        }
    }
}