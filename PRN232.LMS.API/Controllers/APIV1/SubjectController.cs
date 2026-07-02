using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;
using PRN232.LMS.Services;

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
    [Route("api/v{version:apiVersion}/subjects")]
    [Route("api/subjects")]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] QueryParameters query)
        {
            var result = await _subjectService.GetAllAsync(query);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _subjectService.GetByIdAysnc(id);
            if (result == null)
            {
                return NotFound(new { message = $"Subject with id {id} not found" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSubjectRequest request)
        {
            var result = await _subjectService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new
            {
                id = result.Data.SubjectId
            }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateSubjectRequest request)
        {
            var result = await _subjectService.UpdateAsync(id, request);
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
            var result = await _subjectService.DeleteAsync(id);
            if (!result.success)
            {
                return NotFound(result);
            }
            return NoContent();
        }
    }
}