using Microsoft.EntityFrameworkCore;
using TodoList.Applications.Interfaces.Repositories;
using TodoList.Applications.Interfaces.Specifications;
using TodoList.Infrastructures.Persistences.Paginations;
using TodoList.Infrastructures.Persistences.Specifications;

namespace TodoList.Infrastructures.Persistences.Repositories
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class
    {
        public DbContext Context { get; }
        public IQueryable<TEntity> DbSet { get; }
        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
           await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<TEntity?> FindByIdAsync(TId id)
        {
           return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllByConditionAsync<TItem>(System.Linq.Expressions.Expression<Func<TEntity, TItem>> predicate, int pageSize, int pageNumber) where TItem : class
        {
            return await Context.Set<TEntity>().Include(predicate).ToPaginationAsync(pageSize, pageNumber);
        }

        public async Task<IEnumerable<TEntity>> GetAllIncludePagingAsync(int pageSize, int pageNumber)
        {
            return await Context.Set<TEntity>().ToPaginationAsync(pageSize, pageNumber);
        }

        public async Task<int> TotalCountAsync()
        {
            return await DbSet.CountAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetListItemBySpecificationAsync(ISpecification<TEntity> spec, int pageSize, int pageIndex)
        {
            return await SpecificationQuery<TEntity>.QueryListItemAsync(Context.Set<TEntity>(), spec, pageSize, pageIndex);
        }

        public async Task<TEntity> GetItemBySpecificationAsync(ISpecification<TEntity> spec)
        {
            return await SpecificationQuery<TEntity>.QueryItemAsync(Context.Set<TEntity>(), spec);
        }
    }
}
