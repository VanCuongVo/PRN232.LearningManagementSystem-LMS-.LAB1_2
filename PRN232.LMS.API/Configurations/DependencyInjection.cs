using PRN232.LMS.Repositories.IRepositories;
using PRN232.LMS.Repositories.Repositories;
using PRN232.LMS.Services;
using PRN232.LMS.Services.Interfaces;
using PRN232.LMS.Services.IServices;
using PRN232.LMS.Services.Services;

namespace PRN232.LMS.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepositories, StudentRepositoies>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<ISubjectRepositories, SubjectRepositories>();
            services.AddScoped<ISubjectService, SubjectService>();


            services.AddScoped<ISemestersRepositories, SemestersRepositories>();
            services.AddScoped<ISemestersService, SemestersService>();


            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IEnrollmentRepositories, EnrollmentRepositories>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();

            services.AddScoped<IUserRepositories, UserRepositories>();
            services.AddScoped<IRefreshTokenRepositories, RefreshTokenRepositories>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(
                typeof(IGenericRepositories<>),
                typeof(GenericRepositories<>));
            return services;

        }
    }
}