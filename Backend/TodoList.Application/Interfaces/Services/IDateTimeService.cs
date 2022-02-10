namespace TodoList.Applications.Interfaces.Services
{
    public interface IDateTimeService
    {
        DateTimeOffset Now { get; }
        DateTimeOffset UtcNow { get; }
    }
}
