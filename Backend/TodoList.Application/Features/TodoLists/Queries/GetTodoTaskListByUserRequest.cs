using AutoMapper;
using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Interfaces.Services;
using TodoList.Applications.Specifications;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Queries
{
    public class GetTodoTaskListByUserRequest : IRequest<IEnumerable<TodoTaskDto>>
    {
        public GetTodoTaskListByUserRequest(int pageSize, int pageIndex)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetTodoTaskListByUserHandler : IRequestHandler<GetTodoTaskListByUserRequest, IEnumerable<TodoTaskDto>>
    {
        private readonly IAsyncRepository<TodoTask, Guid> _todoTaskRepo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;
        private readonly IIdentityService _identityService;

        public GetTodoTaskListByUserHandler(IAsyncRepository<TodoTask, Guid> todoTaskRepo, IMapper mapper, ICurrentUserService userService, IIdentityService identityService)
        {
            _todoTaskRepo = todoTaskRepo;
            _mapper = mapper;
            _userService = userService;
            _identityService = identityService;
        }

        public async Task<IEnumerable<TodoTaskDto>> Handle(GetTodoTaskListByUserRequest request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetIdByUserNameAsync(_userService.UserName);
            var result = await _todoTaskRepo.GetListItemBySpecificationAsync(new TodoTaskSpecification(Guid.Parse(userId)),request.PageSize, request.PageIndex);
            return _mapper.Map<IEnumerable<TodoTaskDto>>(result);
        }
    }
}
