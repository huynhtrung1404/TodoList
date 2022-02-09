using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Services;

namespace TodoList.Applications.Features.Identity.Commands
{
    public class SignUpRequest : IRequest<bool>
    {
        public SignUpDto SignUpInfo { get; init; }

        public SignUpRequest(SignUpDto signUpInfo)
        {
            SignUpInfo = signUpInfo;
        }
    }

    public class SignUpRequestHandler : IRequestHandler<SignUpRequest, bool>
    {
        private readonly IIdentityService _identityService;

        public SignUpRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<bool> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            return await _identityService.SignUpAsync(request.SignUpInfo);
        }
    }
}
