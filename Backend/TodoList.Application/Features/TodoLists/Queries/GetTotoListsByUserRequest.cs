using AutoMapper;
using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Specifications;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Queries
{
    public class GetTotoListsByUserRequest : IRequest<IEnumerable<TodoTaskDto>>
    {
        public GetTotoListsByUserRequest(Guid userId, int pageSize, int pageIndex)
        {
            UserId = userId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public Guid UserId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetTodoListByUserHandler : IRequestHandler<GetTotoListsByUserRequest, IEnumerable<TodoTaskDto>>
    {
        private readonly IAsyncRepository<TodoTask, Guid> _todoTaskRepo;
        private readonly IMapper _mapper;
        public GetTodoListByUserHandler(IAsyncRepository<TodoTask, Guid> todoTaskRepo, IMapper mapper)
        {
            _todoTaskRepo = todoTaskRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TodoTaskDto>> Handle(GetTotoListsByUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _todoTaskRepo.GetListItemBySpecificationAsync(new TodoTaskSpecification(request.UserId),request.PageSize, request.PageIndex);
            return _mapper.Map<IEnumerable<TodoTaskDto>>(result);
        }
    }
}
