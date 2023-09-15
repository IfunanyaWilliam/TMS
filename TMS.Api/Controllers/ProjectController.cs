namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TMS.Application.Commands.Project;
    using TMS.Domain.Project;

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("project")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProjectAsync(
                            [FromBody] CreateProjectCommandParameter parameters)
        {
            if (parameters == null || parameters.Name == null || parameters.Description == null)
                return BadRequest("CreateProjectAsync: Name or Description should not be empty");

            var response = await _mediator.Send(parameters);

            if (response == null)
                return BadRequest("Project could not be created");

            return Ok(response);
        }
    }
}
