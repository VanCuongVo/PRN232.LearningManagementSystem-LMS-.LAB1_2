using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services.IServices
{
    public interface ICourseService
    {
        Task<ApiResponse<object>> GetAllAsync(
            QueryParameters query);

        Task<CourseResponse?> GetByIdAsync(int id);

        Task<ApiResponse<CourseResponse>> CreateAsync(
            CreateCourseRequest request);

        Task<ApiResponse<CourseResponse>> UpdateAsync(
            int id,
            UpdateCourseRequest request);

        Task<ApiResponse<bool>> DeleteAsync(int id);

        Task<ApiResponse<object>> GetEnrollmentsAsync(int courseId, QueryParameters query);
    }
}