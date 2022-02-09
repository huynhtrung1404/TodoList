using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Applications.Features.TodoLists.Queries;

namespace TodoList.Backend.Controllers
{
    public class TodoTasksController : ApiBaseController
    {
        public TodoTasksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize, int pageIndex)
        {
            return Ok(await _mediator.Send(new GetTodoListsByUserRequest(pageSize, pageIndex)));
        }
    }
}
