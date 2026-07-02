using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;

namespace PRN232.LMS.Services.IServices
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);
        Task<ApiResponse<LoginResponse>> RefreshTokenAsync(RefreshTokenRequest request);
        Task<ApiResponse<UserResponse>> RegisterAsync(CreateUserRequest request);

    }
}