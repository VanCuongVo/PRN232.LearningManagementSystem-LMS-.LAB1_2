using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;
using PRN232.LMS.Services.Services;

namespace PRN232.LMS.API.Controllers.ApiV1
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
    [Route("api/v{version:apiVersion}/semesters")]
    [Route("api/semesters")]
    [Authorize]
    public class SemesterController : ControllerBase
    {
        private readonly ISemestersService _semesterService;

        public SemesterController(ISemestersService semestersService)
        {
            _semesterService = semestersService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(
            [FromQuery] QueryParameters request)
        {
            var result =
                await _semesterService.GetAllAsync(request);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result =
                await _semesterService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateSemesterRequest request)
        {
            var result =
                await _semesterService.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new
            {
                id = result.Data.SemesterId
            }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(
            int id,
            [FromBody] UpdateSemesterRequest request)
        {
            var result =
                await _semesterService.UpdateAsync(id, request);

            if (!result.success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result =
                await _semesterService.DeleteAsync(id);

            if (!result.success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
    }
}