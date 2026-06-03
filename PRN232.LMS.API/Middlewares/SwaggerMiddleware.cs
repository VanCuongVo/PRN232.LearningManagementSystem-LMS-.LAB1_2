namespace PRN232.LMS.API.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static WebApplication UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRN232.LMS API v1");
                c.RoutePrefix = "swagger"; // serve UI at /swagger
            });
            return app;
        }
    }
}