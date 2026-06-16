using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace PRN232.LMS.API.Middlewares
{
    public static class SwaggerMiddleware
    {
        public static WebApplication UseSwaggerConfiguration(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName.ToLowerInvariant()}/swagger.json",
                   description.GroupName.ToLowerInvariant()
);
                }
                options.RoutePrefix = "swagger";
            });

            return app;
        }
    }
}