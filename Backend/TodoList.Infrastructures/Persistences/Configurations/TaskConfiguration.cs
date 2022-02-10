using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Entities.Entities;

namespace TodoList.Infrastructures.Persistences.Configurations
{
    public class TaskConfiguration : AppEntityBaseConfiguration<TodoTask>
    {
        public override void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            base.Configure(builder);
            builder.ToTable("Tasks", x => x.IsTemporal());
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);
        }
    }
}
