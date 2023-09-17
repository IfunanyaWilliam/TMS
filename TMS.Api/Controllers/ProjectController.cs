namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using TMS.Application.Commands.Project;
    using TMS.Application.Queries.Project;
    using TMS.Domain.Project;
    using TMS.Api.Validations;

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
        ///     GET: /api/GetAllProjects
        /// </summary>
        /// <remarks>
        ///     Get all projects
        /// </remarks>
        /// <param name ="pageNumber" ></ param >
        /// <param name ="pageSize"></param>
        /// <param name ="searchParam"></param>
        /// <param name ="ct"></param>
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
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjectsAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchParam = null,
            CancellationToken ct = default)
        {
            var response = await _mediator.Send(new GetAllProjectsQueryParamter(
                                    searchParam: searchParam,
                                    pageNumber: pageNumber,
                                    pageSize: pageSize),
                                    ct);

            if (response == null)
                return Enumerable.Empty<Project>().ToList();

            return Ok(response);
        }

        /// <summary>
        ///     GET: /api/GetProject/Id
        /// </summary>
        /// <remarks>
        ///     Get all projects
        /// </remarks>
        /// <param name ="id" ></ param>
        /// <param name ="ct"></param>
        /// <response code="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpGet("id")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProjectByIdAsync(
            [FromQuery] Guid id, 
            CancellationToken ct = default)
        {
            if (id == Guid.Empty)
                return BadRequest("GetProjectByIdAsync: id should not be empty");

            if(!ValidateGuid.IsValidGuid(id.ToString()))
                return BadRequest("GetProjectByIdAsync: id is not a valid Guid");

            var response = await _mediator.Send(new GetProjectByIdQueryParameter(id: id), ct);

            if (response == null)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                        new { message = $"Project with ID: {id} Not Found." });

            return Ok(response);
        }


        /// <summary>
        ///     POST: /api/CreateProject
        /// </summary>
        /// <remarks>
        ///     Creates a project
        /// </remarks>
        /// <param name ="parameters"></param>
        /// <param name ="ct"></param>
        /// <response code ="200">
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
                            [FromBody] CreateProjectCommandParameter parameters,
                            CancellationToken ct = default)
        {
            if (parameters == null || parameters.Name == null || parameters.Description == null)
                return BadRequest("CreateProjectAsync: Name or Description should not be empty");

            var response = await _mediator.Send(parameters, ct);

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
        /// <param name="ct"></param>
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
                        [FromBody] UpdateProjectCommandParameter parameters,
                        CancellationToken ct = default)
        {
            if (parameters == null)
                return BadRequest("Project parameters are required");

            if (parameters.Id == Guid.Empty)
                return BadRequest("Professional id is required");

            if (!ValidateGuid.IsValidGuid(parameters.Id.ToString()))
                return BadRequest("UpdateProjectAsync: id is not a valid Guid");

            var response = await _mediator.Send(parameters, ct);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new { message = "Something went wrong. Project Could not be modified" });

            return NoContent();
        }

        /// <summary>
        ///     PUT: /api/project/addAppTaskToProject
        /// </summary>
        /// <remarks>
        ///     Adds AppTask to a project
        /// </remarks>
        /// <param name ="parameters"></param>
        /// <param name ="ct"></param>
        /// <response code ="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpPut("addAppTaskToProject")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAppTaskToProjectAsync(
                    [FromBody] AddAppTaskToProjectCommandParameter parameters,
                    CancellationToken ct = default)
        {
            if (parameters.ProjectId == Guid.Empty || parameters.AppTaskId == Guid.Empty)
                return BadRequest($"AddAppTaskToProjectAsync: Parameters {parameters.AppTaskId} and {parameters.ProjectId} are required");

            var response = await _mediator.Send(parameters, ct);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong. AppTask could not be added to Project" });

            return NoContent();
        }

        /// <summary>
        ///     PUT: /api/project/removeAppTaskFromProject
        /// </summary>
        /// <remarks>
        ///     Removes AppTask from a project
        /// </remarks>
        /// <param name ="parameters"></param>
        /// <param name ="ct"></param>
        /// <response code ="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpPut("project/removeAppTaskFromProject")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveAppTaskFromProjectAsync(
                    [FromBody] RemoveAppTaskFromProjectCommandParameter parameters,
                    CancellationToken ct = default)
        {
            if (parameters.ProjectId == Guid.Empty || parameters.AppTaskId == Guid.Empty)
                return BadRequest($"AddAppTaskToProjectAsync: Parameters {parameters.AppTaskId} and {parameters.ProjectId} are required");

            var response = await _mediator.Send(parameters, ct);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong. AppTask could not be removed from Project" });

            return NoContent();
        }

        /// <summary>
        ///     DELETE: /api/project
        /// </summary>
        /// <remarks>
        ///     Archives a project 
        /// </remarks>
        /// <param name="parameters"></param>
        /// <param name="ct"></param>
        /// <response code="204">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProjectAsync(
            DeleteProjectCommandParameter parameters, 
            CancellationToken ct = default)
        {
            if (parameters == null)
                return BadRequest("Project parameters are required");

            if (parameters.Id == Guid.Empty)
                return BadRequest("Project id is required");

            if (!ValidateGuid.IsValidGuid(parameters.Id.ToString()))
                return BadRequest($"DeleteProjectAsync: {parameters.Id} is not a valid Guid");

            var response = await _mediator.Send(parameters);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong. Project Could not be deleted" });

            return NoContent();
        }
    }
}
