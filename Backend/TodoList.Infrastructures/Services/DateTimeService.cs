using TodoList.Applications.Interfaces.Services;

namespace TodoList.Infrastructures.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTimeOffset Now => DateTime.UtcNow;

        public DateTimeOffset UtcNow => DateTime.UtcNow;
    }
}
