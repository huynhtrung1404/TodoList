namespace TodoList.Entities.Entities
{
    public abstract class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
