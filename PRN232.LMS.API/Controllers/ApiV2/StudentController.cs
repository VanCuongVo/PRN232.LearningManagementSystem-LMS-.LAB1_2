using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;
using PRN232.LMS.Services.IServices;


namespace PRN232.LMS.API.Controllers.ApiV2
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
    [Route("api/v{version:apiVersion}/students")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<StudentResponse>>>> GetAll([FromQuery] QueryParameters query)
        {
            var result = await _studentService.GetAllAsync(query);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            var result = await _studentService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(new { message = $"Student with id {id} not found" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
        {
            try
            {
                var result = await _studentService.CreateAsync(request);

                if (!result.success)
                {
                    return BadRequest(result);
                }

                return CreatedAtAction(nameof(GetById), new
                {
                    id = result.Data.StudentId
                }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequest request)
        {
            try
            {
                var result = await _studentService.UpdateAsync(id, request);

                if (!result.success)
                {
                    return NotFound(result);
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (!result.success)
            {
                return NotFound(result);
            }

            return NoContent();
        }
    }
}
