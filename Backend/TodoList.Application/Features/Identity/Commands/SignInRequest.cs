using MediatR;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Services;

namespace TodoList.Applications.Features.Identity.Commands
{
    public class SignInRequest : IRequest<UserInformationDto>
    {
        public SignInDto SignInInfo { get; init; }
        public SignInRequest(SignInDto signInInfo)
        {
            SignInInfo = signInInfo;
        }
    }

    public class SignInRequestHandler : IRequestHandler<SignInRequest, UserInformationDto>
    {
        private readonly IIdentityService _identityService;

        public SignInRequestHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UserInformationDto> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            return await _identityService.SignInAsync(request.SignInInfo);
        }
    }
}
