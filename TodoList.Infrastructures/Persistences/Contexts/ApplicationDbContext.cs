using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructures.Persistences.Configurations;
using TodoList.Entities.Entities;
using TodoList.Infrastructures.Persistences.Identities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Infrastructures.Persistences.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<TodoListUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var assembly = typeof(AppEntityBaseConfiguration<>).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
            builder.HasDefaultSchema("Todo");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
