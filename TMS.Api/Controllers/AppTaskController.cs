namespace TMS.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;



    [ApiController]
    [Route("api/[controller]")]
    public class AppTaskController : Controller
    {
        private readonly IMediator _mediator;

        public AppTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}