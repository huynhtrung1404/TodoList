using MediatR;
using TodoList.Applications.Interfaces.Services;

namespace TodoList.Applications.Features.Identity.Commands
{
    public class AddNewRoleRequest : IRequest<bool>
    {
        public string Role { get; init; }
        public AddNewRoleRequest(string role)
        {
            Role = role;
        }
    }

    public class AddNewRoleRequestHandler : IRequestHandler<AddNewRoleRequest, bool>
    {
        private readonly IIdentityService _identityService;

        public AddNewRoleRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(AddNewRoleRequest request, CancellationToken cancellationToken)
        {
            return await _identityService.AddNewRoleAsync(request.Role);
        }
    }
}
