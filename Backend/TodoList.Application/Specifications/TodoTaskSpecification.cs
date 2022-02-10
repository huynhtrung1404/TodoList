using TodoList.Entities.Entities;

namespace TodoList.Applications.Specifications
{
    public class TodoTaskSpecification : BaseSpecification<TodoTask>
    {
        public TodoTaskSpecification(Guid userId) : base(x => x.UserId.Equals(userId))
        {
            AddInclude(x => x.Category);
        }

        public TodoTaskSpecification(Guid userId, Guid todoListId) : base(x => x.Id.Equals(todoListId) && x.UserId.Equals(userId))
        {
            AddInclude(x => x.Category);
        }

    }
}
