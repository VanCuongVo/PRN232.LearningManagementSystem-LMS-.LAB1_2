using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN232.LMS.Models.RequestModel;
using PRN232.LMS.Models.ResponseModel;
using PRN232.LMS.Services;

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
    [Route("api/v{version:apiVersion}/subjects")]

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
            await _subjectService.UpdateAsync(id, request);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _subjectService.DeleteAsync(id);
            return NoContent();
        }
    }
}