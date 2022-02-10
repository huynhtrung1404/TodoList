namespace TodoList.Entities.Entities
{
    public class TodoTask : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DueDate { get; set; }
        public Guid PriorityId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Priority Priority { get; set; }
        public Guid UserId { get; set; }
    }
}
