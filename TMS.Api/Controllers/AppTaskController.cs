namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Domain.AppTask;
    using TMS.Application.Commands.AppTask;
    using TMS.Application.Queries.Project;
    using TMS.Application.Queries.AppTask;

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
    }
}