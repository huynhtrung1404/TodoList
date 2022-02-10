using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Applications.Dtos;
using TodoList.Applications.Features.TodoLists.Commands;
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
            return Ok(await _mediator.Send(new GetTodoTaskListByUserRequest(pageSize, pageIndex)));
        }

        [HttpGet("TodoTaskDetail/{id}")]
        public async Task<IActionResult> GetTodoTaskDetail(Guid id)
        {
            return Ok(await _mediator.Send(new GetTodoTaskDetailRequest(id)));
        }

        [HttpPost("AddNewItem")]
        public async Task<IActionResult> AddNewItem([FromBody] TodoTaskDto todoTask)
        {
            return Ok(await _mediator.Send(new AddNewTaskRequest(todoTask)));
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] TodoTaskDto todoTask)
        {
            return Ok(await _mediator.Send(new UpdateTotoTaskDetailRequest(todoTask)));
        }

        [HttpDelete("RemoveTask")]
        public async Task<IActionResult> RemoveTask(Guid id)
        {
            return Ok(await _mediator.Send(new RemoveTaskRequest(id)));
        }
    }
}
