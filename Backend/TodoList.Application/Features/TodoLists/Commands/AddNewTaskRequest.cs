using AutoMapper;
using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Commands
{
    public class AddNewTaskRequest : IRequest<Unit>
    {
        public TodoTaskDto TodoTask { get; init; }

        public AddNewTaskRequest(TodoTaskDto todoTask)
        {
            TodoTask = todoTask;
        }
    }

    public class AddNewTaskRequestHandler : IRequestHandler<AddNewTaskRequest, Unit>
    {
        private readonly IAsyncRepository<TodoTask, Guid> _todoTaskRepository;
        private readonly IMapper _mapper;

        public AddNewTaskRequestHandler(IAsyncRepository<TodoTask, Guid> todoTaskrepository, IMapper mapper)
        {
            _todoTaskRepository = todoTaskrepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddNewTaskRequest request, CancellationToken cancellationToken)
        {
            await _todoTaskRepository.AddAsync(_mapper.Map<TodoTask>(request.TodoTask));
            return Unit.Value;
        }
    }

}
