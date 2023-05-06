namespace TodoList.Infrastructures.Persistences.Paginations
{
    public static class PagingExtension
    {
        public async static Task<IEnumerable<T>> ToPaginationAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize) where T : class
        {
            return await PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
        }
    }
}
