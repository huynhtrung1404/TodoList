using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.Applications.Dtos;
using TodoList.Applications.Interfaces.Services;
using TodoList.Infrastructures.Persistences.Identities.Models;

namespace TodoList.Infrastructures.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<TodoListUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IDateTimeService _dateTimeService;

        public IdentityService(RoleManager<IdentityRole<Guid>> roleManager, UserManager<TodoListUser> userManager, IConfiguration configuration, IDateTimeService dateTimeService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _dateTimeService = dateTimeService;
        }

        public Task<bool> AddNewRoleAsync(string role)
        {
            throw new NotImplementedException();
        }

        public async Task<UserInformationDto> SignInAsync(SignInDto signInInfo)
        {
            var user = await _userManager.FindByNameAsync(signInInfo.UserName);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, signInInfo.Password)))
            {
                throw new Exception("Password is not true");
            }
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role,userRoles.FirstOrDefault() == null ? String.Empty : userRoles.First())
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:ValidIssuer"],
                audience: _configuration["JwtConfig:ValidAudience"],
                expires: _dateTimeService.Now.DateTime.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
             );
            return new UserInformationDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                Dob = user.DOB,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<bool> SignUpAsync(SignUpDto signUpInfo)
        {
            var user = await _userManager.FindByNameAsync(signUpInfo.UserName);

            if (user != null)
            {
                throw new Exception("User is existing");
            }

            var todoListUser = new TodoListUser
            {
                UserName = signUpInfo.UserName,
                FirstName = signUpInfo.FirstName,
                SecurityStamp = Guid.NewGuid().ToString(),
                LastName = signUpInfo.LastName,
                FullName = $"{signUpInfo.FirstName} {signUpInfo.LastName}",
                Email = signUpInfo.Email,
            };

            var result = await _userManager.CreateAsync(todoListUser, signUpInfo.Password);

            return result.Succeeded;
        }
    }
}
