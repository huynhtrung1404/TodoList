using TodoList.Applications.Interfaces.Repositories;
using TodoList.Infrastructures.Persistences.Contexts;

namespace TodoList.Infrastructures.Persistences.Repositories
{
    public class AsyncRepository<TEntity, TId> : GenericRepository<TEntity, TId>, IAsyncRepository<TEntity, TId> where TEntity : class
    {
        public AsyncRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
