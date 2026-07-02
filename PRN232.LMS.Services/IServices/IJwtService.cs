using PRN232.LMS.Repositories.RequestModel;

namespace PRN232.LMS.Services.IServices
{
    public interface IJwtService
    {
        Task<string> GenerateToken(UserRequest user);
        string GenerateRefreshToken();
    }
}