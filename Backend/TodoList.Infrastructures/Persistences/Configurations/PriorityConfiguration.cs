using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Entities.Entities;

namespace TodoList.Infrastructures.Persistences.Configurations
{
    public class PriorityConfiguration : AppEntityBaseConfiguration<Priority>
    {
        public override void Configure(EntityTypeBuilder<Priority> builder)
        {
            base.Configure(builder);
            builder.ToTable("Priorities", x => x.IsTemporal());
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
