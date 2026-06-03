using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN232.LMS.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PRN232.LMS API", Version = "v1" });
                options.OperationFilter<LowercaseQueryParameterFilter>();
                options.OperationFilter<ProducesResponseTypeOperationFilter>();

            });
            return services;
        }
    }
}