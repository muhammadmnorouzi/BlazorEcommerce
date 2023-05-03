namespace BlazorEcommerce.Server.Helpers.Pagination;

public static class PagedList<T>
{
    public static async Task<PaginationResult<T>> CreateAsync(
        IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArrayAsync();

        return new PaginationResult<T>(items, count, pageNumber, pageSize, (int)count / pageSize);
    }
}
