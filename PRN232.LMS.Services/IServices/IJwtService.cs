using PRN232.LMS.Models.RequestModel;

namespace PRN232.LMS.Services.IServices
{
    public interface IJwtService
    {
        Task<string> GenerateToken(UserRequest user);
        string GenerateRefreshToken();
    }
}