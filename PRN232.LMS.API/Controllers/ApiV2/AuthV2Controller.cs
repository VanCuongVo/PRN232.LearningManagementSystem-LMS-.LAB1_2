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
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthV2Controller : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthV2Controller(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            var result = await _authService.RegisterAsync(request);

            return Ok(new
            {
                success = true,
                message = "V2 register success",
                data = result
            });
        }
    }
}