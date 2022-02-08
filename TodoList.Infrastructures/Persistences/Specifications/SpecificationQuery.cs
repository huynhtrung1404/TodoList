using Microsoft.EntityFrameworkCore;
using TodoList.Applications.Interfaces.Specifications;
using TodoList.Entities.Entities;

namespace TodoList.Infrastructures.Persistences.Specifications
{
    public static class SpecificationQuery<TItem> where TItem : class
    {
        public static IQueryable<TItem> QueryListItem(IQueryable<TItem> items, ISpecification<TItem> spec)
        {
            var query = items;
            query = spec.Includes
             .Aggregate(query,
           (current, include) => current.Include(include));

            query = spec.IncludeStrings
                .Aggregate(query,
                  (current, include) => current.Include(include));

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }

        public static TItem QueryItem(IQueryable<TItem> items, ISpecification<TItem> spec)
        {

            var query = items;
            query = spec.Includes
             .Aggregate(query,
           (current, include) => current.Include(include));

            query = spec.IncludeStrings
                .Aggregate(query,
                  (current, include) => current.Include(include));

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return query.First();
        }
   

        public static async Task<TItem> QueryItemAsync(IQueryable<TItem> items, ISpecification<TItem> spec)
        {

            var query = items;
            query = spec.Includes
             .Aggregate(query,
           (current, include) => current.Include(include));

            query = spec.IncludeStrings
                .Aggregate(query,
                  (current, include) => current.Include(include));

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            return await query.FirstAsync();
        }
    }
}
