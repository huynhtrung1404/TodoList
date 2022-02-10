using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Interfaces.Services;
using TodoList.Applications.Specifications;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Features.TodoLists.Queries
{
    public class GetTodoTaskDetailRequest : IRequest<TodoTaskDto>
    {
        public Guid Id { get; init; }

        public GetTodoTaskDetailRequest(Guid id)
        {
            Id = id;
        }
    }

    public class GetTodoTaskDetailRequestHandler : IRequestHandler<GetTodoTaskDetailRequest, TodoTaskDto>
    {
        private readonly IAsyncRepository<TodoTask,Guid> _todoTaskRepository;
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetTodoTaskDetailRequestHandler(IAsyncRepository<TodoTask, Guid> todoTaskRepository, IIdentityService identityService, ICurrentUserService currentUserService, IMapper mapper)
        {
            _todoTaskRepository = todoTaskRepository;
            _identityService = identityService;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<TodoTaskDto> Handle(GetTodoTaskDetailRequest request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetIdByUserNameAsync(_currentUserService.UserName);
            var task = await _todoTaskRepository.GetItemBySpecificationAsync(new TodoTaskSpecification(Guid.Parse(userId), request.Id));
            return _mapper.Map<TodoTaskDto>(task);
        }
    }

}
