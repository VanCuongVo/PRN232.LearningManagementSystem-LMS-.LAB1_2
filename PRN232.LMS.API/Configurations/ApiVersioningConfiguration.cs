using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
namespace PRN232.LMS.API.Configurations
{
    public static class ApiVersioningConfiguration
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        // URL Versioning
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    });
            services.AddVersionedApiExplorer(options =>
          {
              options.GroupNameFormat = "'v'VVV";
              options.SubstituteApiVersionInUrl = true;
          });
            return services;
        }
    }

}