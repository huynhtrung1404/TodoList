using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Entities.Entities;

namespace TodoList.Infrastructures.Persistences.Configurations
{
    public class AppEntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity<Guid>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
