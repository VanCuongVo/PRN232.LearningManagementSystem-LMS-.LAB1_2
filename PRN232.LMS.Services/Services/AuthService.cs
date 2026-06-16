using Microsoft.Extensions.Configuration;
using PRN232.LMS.Models.Entities;
using PRN232.LMS.Models.RequestModel;
using PRN232.LMS.Models.ResponseModel;
using PRN232.LMS.Repositories.IRepositories;
using PRN232.LMS.Services.IServices;

namespace PRN232.LMS.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IJwtService jwtService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _configuration = configuration;
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(request.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.PassWord, user.PasswordHash)) return null;
            var token = await _jwtService.GenerateToken(new UserRequest
            {
                Id = user.UserId,
                Name = user.Username,
                Email = user.Student?.Email,
                Role = user.Role
            });
            var refreshToken = _jwtService.GenerateRefreshToken();
            await _unitOfWork.RefreshTokens.AddAsync(new Models.Entities.RefreshToken
            {
                UserId = user.UserId,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(double.Parse(_configuration.GetSection("Jwt")["RefreshTokenExpirationDays"] ?? "7")),
                IsRevoked = false
            });
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<LoginResponse>
            {
                success = true,
                message = "Login successful",
                Data = new LoginResponse
                {
                    AccessToken = token,
                    RefreshToken = refreshToken,
                    ExpiresIn = (int)TimeSpan.FromMinutes(double.Parse(_configuration.GetSection("Jwt")["AccessTokenExpirationMinutes"] ?? "60")).TotalSeconds
                }
            };
        }

        public async Task<ApiResponse<LoginResponse>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var existingToken = await _unitOfWork.RefreshTokens.GetByTokenAsync(request.RefreshToken);
            if (existingToken == null)
            {
                return new ApiResponse<LoginResponse>
                {
                    success = false,
                    message = "Invalid refresh token"
                };
            }
            if (existingToken.IsRevoked)
            {
                return new ApiResponse<LoginResponse>
                {
                    success = false,
                    message = "Refresh token has been revoked"
                };
            }

            if (existingToken.ExpiryDate < DateTime.UtcNow)
            {
                return new ApiResponse<LoginResponse>
                {
                    success = false,
                    message = "Refresh token expired"
                };
            }

            var user = existingToken.User; // lấy ra obj đang sở hữu cái resfeshToken
            var accessToken = await _jwtService.GenerateToken(new UserRequest
            {
                Id = user.UserId,
                Name = user.Username,
                Email = user.Student?.Email,
                Role = user.Role
            });

            existingToken.IsRevoked = true;

            var newRefreshToken = _jwtService.GenerateRefreshToken();
            await _unitOfWork.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = user.UserId,
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(double.Parse(_configuration.GetSection("Jwt")["RefreshTokenExpirationDays"] ?? "7")),
                IsRevoked = false
            });
            await _unitOfWork.SaveChangesAsync();
            return new ApiResponse<LoginResponse>
            {
                success = true,
                message = "Token refreshed successfully",
                Data = new LoginResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken,
                    ExpiresIn = (int)TimeSpan.FromMinutes(double.Parse(_configuration.GetSection("Jwt")["AccessTokenExpirationMinutes"] ?? "60")).TotalSeconds

                }
            };
        }

        public async Task<ApiResponse<UserResponse>> RegisterAsync(CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Role = request.Role,
                StudentId = request.StudentId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<UserResponse>
            {
                success = true,
                message = "Register successfully",
                Data = new UserResponse
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.Role,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                }
            };
        }
    }
}