namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TMS.Application.Commands.Project;
    using TMS.Application.Queries.Project;
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

        /// <summary>
        ///     PUT: /api/GetAllProjects
        /// </summary>
        /// <remarks>
        ///     Get all projects
        /// </remarks>
        /// <param name = "pageNumber" ></ param >
        /// <param name="pageSize"></param>
        /// <param name="searchParam"></param>
        /// <response code="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProjectsAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchParam = null,
            CancellationToken ct = default)
        {
            var response = await _mediator.Send(new GetAllProjectsQueryParamter(
                searchParam: searchParam,
                pageNumber: pageNumber,
                pageSize: pageSize));

            if (response == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong." });

            return Ok(response);
        }


        /// <summary>
        ///     PUT: /api/CreateProject
        /// </summary>
        /// <remarks>
        ///     Updates a project
        /// </remarks>
        /// <param name="parameters"></param>
        /// <response code="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpPost("CreateProject")]
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

        /// <summary>
        ///     PUT: /api/project
        /// </summary>
        /// <remarks>
        ///     Updates a project
        /// </remarks>
        /// <param name="parameters"></param>
        /// <response code="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProjectAsync(
                        [FromBody] UpdateProjectCommandParameter parameters)
        {
            if (parameters == null)
                return BadRequest("Project parameters are required");

            if (parameters.Id == Guid.Empty)
                return BadRequest("Professional id is required");

            var response = await _mediator.Send(parameters);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Something went wrong. Project Could not be modified" });

            return NoContent();
        }
    }
}
