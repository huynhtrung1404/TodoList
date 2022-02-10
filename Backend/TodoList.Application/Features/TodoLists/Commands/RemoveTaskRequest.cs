using MediatR;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Commands
{
    public class RemoveTaskRequest : IRequest<Unit>
    {
        public Guid Id { get; init; }

        public RemoveTaskRequest(Guid id)
        {
            Id = id;
        }
    }

    public class RemoveTaskRequestHandler : IRequestHandler<RemoveTaskRequest, Unit>
    {
        private readonly IAsyncRepository<TodoTask, Guid> _todoTaskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskRequestHandler(IAsyncRepository<TodoTask, Guid> todoTaskRepository, IUnitOfWork unitOfWork)
        {
            _todoTaskRepository = todoTaskRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _todoTaskRepository.FindByIdAsync(request.Id);
            if (task == null)
            {
                throw new Exception("Task is not existing");
            }
            _todoTaskRepository.Delete(task);
            _unitOfWork.CommitChanges();

            return Unit.Value;
        }
    }
}
