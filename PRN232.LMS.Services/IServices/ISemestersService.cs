using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services.Services
{
    public interface ISemestersService
    {
        Task<ApiResponse<object>> GetAllAsync(QueryParameters query);
        Task<SemesterResponse> GetByIdAsync(int id);
        Task<ApiResponse<SemesterResponse>> CreateAsync(CreateSemesterRequest request);

        Task<ApiResponse<SemesterResponse>> UpdateAsync(int id, UpdateSemesterRequest request);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}