namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Domain.AppTask;
    using Application.Commands.AppTask;
    using Application.Queries.AppTask;
    using Validations;

    [ApiController]
    [Route("api/[controller]")]
    public class AppTaskController : Controller
    {
        private readonly IMediator _mediator;

        public AppTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     GET: /api/GetAllAppTasks
        /// </summary>
        /// <remarks>
        ///     Get all projects
        /// </remarks>
        /// <param name ="pageNumber" ></ param >
        /// <param name ="pageSize"></param>
        /// <param name ="searchParam"></param>
        /// <param name ="ct"></param>
        /// <response code="200">
        ///     Operation was successful.
        /// </response>
        /// <response code="400">
        ///     Bad Request.
        /// </response>
        /// <response code = "500" >
        ///     Internal Server Error.
        /// </response>
        [HttpGet("all")]
        [ProducesResponseType(typeof(AppTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<AppTask>>> GetAllAppTasksAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchParam = null,
            CancellationToken ct = default)
        {
            var response = await _mediator.Send(new GetAllAppTasksQueryParameter(
                                    pageNumber: pageNumber,
                                    pageSize: pageSize,
                                    searchParam: searchParam),
                                    ct);

            if (response == null)
                return Enumerable.Empty<AppTask>().ToList();

            return Ok(response);
        }

        /// <summary>
        ///     GET: /api/appTask/Id
        /// </summary>
        /// <remarks>
        ///     Gets an AppTask
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
        [ProducesResponseType(typeof(AppTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAppTaskByIdAsync(
            [FromQuery] Guid id,
            CancellationToken ct = default)
        {
            if (id == Guid.Empty)
                return BadRequest("GetAppTaskByIdAsync: id should not be empty");

            if (!ValidateGuid.IsValidGuid(id.ToString()))
                return BadRequest($"GetAppTaskByIdAsync: {id} is not a valid Guid");

            var response = await _mediator.Send(new GetAppTaskByIdQueryParameter(id: id), ct);

            if (response == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { message = $"AppTask with ID: {id} Not Found." });

            return Ok(response);
        }

        /// <summary>
        ///     POST: /api/CreateAppTask
        /// </summary>
        /// <remarks>
        ///     Updates a project
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
        [HttpPost("CreateAppTask")]
        [ProducesResponseType(typeof(AppTask), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAppTaskAsync(
                    [FromBody] CreateAppTaskCommandParameter parameters, 
                    CancellationToken ct = default)
        {
            if (parameters == null || parameters.Title == null || parameters.Description == null
                || parameters.DueDate == null || parameters.Status == null || parameters.Priority == null)
            {
                return BadRequest($"CreateAppTaskAsync: The Parameters : {parameters.Title}, {parameters.Description}, " +
                                   $"{parameters.DueDate}, {parameters.Status}, {parameters.Priority}, should not be empty");
            }

            var response = await _mediator.Send(parameters, ct);

            if (response == null)
                return BadRequest("AppTask could not be created");

            return Ok(response);
        }

        /// <summary>
        ///     PUT: /api/appTask
        /// </summary>
        /// <remarks>
        ///     Updates a appTask
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
        public async Task<IActionResult> UpdateAppTaskAsync(
                        [FromBody] UpdateAppTaskCommandParameter parameters,
                        CancellationToken ct = default)
        {
            if (parameters == null)
                return BadRequest("AppTask parameters are required");

            if (parameters.Id == Guid.Empty)
                return BadRequest("AppTask id is required");

            if (!ValidateGuid.IsValidGuid(parameters.Id.ToString()))
                return BadRequest($"UpdateAppTaskAsync: {parameters.Id} is not a valid Guid");

            var response = await _mediator.Send(parameters, ct);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong. AppTask Could not be modified" });

            return NoContent();
        }

        /// <summary>
        ///     DELETE: /api/appTask
        /// </summary>
        /// <remarks>
        ///     Deletes an AppTask 
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
        public async Task<IActionResult> DeleteAppTaskAsync(
                        DeleteAppTaskCommandParameter parameters,
                        CancellationToken ct = default)
        {
            if (parameters == null)
                return BadRequest("AppTask parameters are required");

            if (parameters.Id == Guid.Empty)
                return BadRequest($"AppTask {parameters.Id} is required");

            if (!ValidateGuid.IsValidGuid(parameters.Id.ToString()))
                return BadRequest($"DeleteAppTaskAsync: {parameters.Id} is not a valid Guid");

            var response = await _mediator.Send(parameters);

            if (response == false)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Something went wrong. AppTask Could not be deleted" });

            return NoContent();
        }
    }
}