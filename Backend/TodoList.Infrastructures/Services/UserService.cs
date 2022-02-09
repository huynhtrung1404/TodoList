using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TodoList.Applications.Interfaces.Services;
using TodoList.Infrastructures.Persistences.Identities.Models;

namespace TodoList.Infrastructures.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<TodoListUser> _userManager;

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
