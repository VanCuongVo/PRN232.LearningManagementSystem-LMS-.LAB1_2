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
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<ActionResult<object>> GetAll(
         [FromQuery] QueryParameters request)
        {
            var result = await _courseService.GetAllAsync(request);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result =
                await _courseService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Course not found"
                });
            }

            return Ok(result);
        }

        [HttpGet("{id}/enrollments")]
        public async Task<IActionResult> GetEnrollments(
       int id,
       [FromQuery] QueryParameters query)
        {
            var result = await _courseService.GetEnrollmentsAsync(id, query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] CreateCourseRequest request)
        {
            var result =
                await _courseService.CreateAsync(request);


            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Data.CourseId },
                result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateCourseRequest request)
        {
            var result = await _courseService.UpdateAsync(id, request);

            if (!result.success)
            {
                return NotFound(result);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result =
                await _courseService.DeleteAsync(id);

            if (!result.success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
    }
}
