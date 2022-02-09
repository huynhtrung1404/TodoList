namespace TodoList.Entities.Entities
{
    public class Priority : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<TodoTask> Tasks { get; set; }
    }
}
