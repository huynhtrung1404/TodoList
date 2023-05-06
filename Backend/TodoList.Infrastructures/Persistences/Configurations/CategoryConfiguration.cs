using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Entities.Entities;

namespace TodoList.Infrastructures.Persistences.Configurations
{
    public class CategoryConfiguration : AppEntityBaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories", x => x.IsTemporal());
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
