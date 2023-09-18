namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Domain.User;
    using TMS.Application.Commands.User;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        ///     POST: /api/createUser
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
        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAsync(
            CreateUserCommandParameter parameters,
            CancellationToken ct = default)
        {
            if (parameters == null || parameters.FirstName == null || parameters.LastName == null 
                || parameters.Email == null || parameters.Password == null)
                return BadRequest("CreateUserAsync: Parameters FirstName, LastName, Email, Password are required");


            var response = await _mediator.Send(parameters, ct);

            if (response == null)
                return BadRequest("Project could not be created");

            return Ok(response);
        }

    }
}
