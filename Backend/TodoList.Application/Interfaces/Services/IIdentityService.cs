using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Applications.Dtos;

namespace TodoList.Applications.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<UserInformationDto> SignInAsync(SignInDto signInInfo);
        Task<bool> SignUpAsync(SignUpDto signUpInfo);
        Task<bool> AddNewRoleAsync(string role);
        Task<string> GetIdByUserNameAsync(string userName);
    }
}
