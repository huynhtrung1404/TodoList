using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Interfaces.Services;
using TodoList.Infrastructures.Persistences.Contexts;
using TodoList.Infrastructures.Persistences.Identities.Models;
using TodoList.Infrastructures.Persistences.Repositories;
using TodoList.Infrastructures.Services;
using TodoList.Shared.CrossCutting.Constant;

namespace TodoList.Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(config.GetConnectionString(ConfigurationVariable.ConnectionString)));
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient(typeof(IAsyncRepository<,>), typeof(AsyncRepository<,>));
            services.AddIdentity<TodoListUser, IdentityRole<Guid>>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
