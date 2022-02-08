namespace TodoList.Applications.Interfaces.Services
{
    public interface IUserService
    {
        string UserName { get; }
        string Token { get; }
        string Role { get; }

    }
}
