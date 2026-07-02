using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services
{
    public interface ISubjectService
    {
        Task<ApiResponse<IEnumerable<SubjectResponse>>> GetAllAsync(QueryParameters query);
        Task<SubjectResponse> GetByIdAysnc(int id);
        Task<ApiResponse<SubjectResponse>> CreateAsync(CreateSubjectRequest request);
        Task<ApiResponse<SubjectResponse>> UpdateAsync(int id, UpdateSubjectRequest request);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}