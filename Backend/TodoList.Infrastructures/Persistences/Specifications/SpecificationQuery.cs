using Microsoft.EntityFrameworkCore;
using TodoList.Applications.Interfaces.Specifications;
using TodoList.Infrastructures.Persistences.Paginations;

namespace TodoList.Infrastructures.Persistences.Specifications
{
    public static class SpecificationQuery<TItem> where TItem : class
    {
        public static async Task<IQueryable<TItem>> QueryListItemAsync(IQueryable<TItem> items, ISpecification<TItem> spec, int pageSize, int pageNumber)
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
               var data = await query.Where(spec.Criteria).ToPaginationAsync(pageSize, pageNumber);
               query = data.AsQueryable();
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

            return await query.SingleAsync();
        }
    }
}
