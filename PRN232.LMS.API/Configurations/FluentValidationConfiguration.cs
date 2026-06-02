using FluentValidation;
using FluentValidation.AspNetCore;
using PRN232.LMS.Models.RequestModel;
using PRN232.LMS.Services.Validators;
using PRN232.LMS.Services.Validators.CourseValidators;
using PRN232.LMS.Services.Validators.SubjectValidators;
using PRN232.LMS.Services.Validators.SubjectValidators.Command;


namespace PRN232.LMS.API.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateStudentRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateStudentRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCourseRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCourseRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateSubjectRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateSubjectRequestValidator>();
            return services;
        }
    }
}