namespace TodoList.Entities.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TodoTask> Tasks { get; set; }
    }
}
