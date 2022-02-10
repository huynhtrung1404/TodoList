using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
