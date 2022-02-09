using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TodoList.Applications.Interfaces.Services;

namespace TodoList.Infrastructures.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserName
        {
            get
            {
                if (_httpContextAccessor.HttpContext == null)
                {
                    return string.Empty;
                }
                return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
        public string Token => throw new NotImplementedException();

        public string Role => throw new NotImplementedException();
    }
}
