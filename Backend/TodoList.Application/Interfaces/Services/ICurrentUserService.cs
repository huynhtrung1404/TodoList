namespace TodoList.Applications.Interfaces.Services
{
    public interface ICurrentUserService
    {
        string UserName { get; }
        string Role { get; }

    }
}
