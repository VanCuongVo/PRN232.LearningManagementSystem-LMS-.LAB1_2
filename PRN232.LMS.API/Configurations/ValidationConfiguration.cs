using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.API.Configurations;

public static class ValidationConfiguration
{
    public static IServiceCollection AddValidationConfiguration(
        this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(x => x.Value!.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    );

                var response = new ApiResponse<object>
                {
                    success = false,

                    message = "Validation failed",

                    Errors = errors
                };

                return new BadRequestObjectResult(response);
            };
        });
        return services;
    }
}