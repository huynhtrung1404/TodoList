using AutoMapper;
using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Interfaces.Services;
using TodoList.Applications.Specifications;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Commands
{
    public class UpdateTotoTaskDetailRequest : IRequest<Unit>
    {
        public TodoTaskDto TodoTask { get; init; }

        public UpdateTotoTaskDetailRequest(TodoTaskDto todoTask)
        {
            TodoTask = todoTask;
        }
    }

    public class UpdateTodoTaskDetailRequestHandler : IRequestHandler<UpdateTotoTaskDetailRequest, Unit>
    {
        private readonly IAsyncRepository<TodoTask, Guid> _todoTaskRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTodoTaskDetailRequestHandler(IAsyncRepository<TodoTask, Guid> todoTaskRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _todoTaskRepository = todoTaskRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateTotoTaskDetailRequest request, CancellationToken cancellationToken)
        {
            var data = await _todoTaskRepository.GetItemBySpecificationAsync(new TodoTaskSpecification(request.TodoTask.UserId, request.TodoTask.Id));
            if (data == null)
            {
                throw new Exception("Task is not existed");
            }
            
            data = _mapper.Map<TodoTask>(request.TodoTask);
            _todoTaskRepository.Update(data);
            _unitOfWork.CommitChanges();
            return Unit.Value;
        }
    }
}
