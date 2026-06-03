


using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Models.RequestModel;
using PRN232.LMS.Models.ResponseModel;
using PRN232.LMS.Services.IServices;

namespace PRN232.LMS.API.Controllers
{

    [ProducesResponseType(
    typeof(ApiResponse<object>),
    StatusCodes.Status200OK,
    "application/json",
    "application/xml",
    "text/csv",
    "text/html"
)]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (result == null || !result.success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshTokenAsync(request);

            if (result == null || !result.success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}