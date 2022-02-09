using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Applications.Dtos;
using TodoList.Applications.Features.Identity.Commands;

namespace TodoList.Backend.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signIn)
        {
            return Ok(await _mediator.Send(new SignInRequest(signIn)));
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUp)
        {
            return Ok(await _mediator.Send(new SignUpRequest(signUp)));
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            return Ok(await _mediator.Send(new AddNewRoleRequest(role)));
        }
    }
}
