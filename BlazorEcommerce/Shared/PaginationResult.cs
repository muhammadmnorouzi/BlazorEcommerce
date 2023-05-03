namespace BlazorEcommerce.Shared;

public class PaginationResult<T>
{
    public PaginationResult()
    {
    }

    public PaginationResult(T[] items, int count, int pageNumber, int pageSize, int totalPages)
    {
        Items = items;
        TotalItems = count;
        CurrentPage = pageNumber;
        ItemsPerPage = pageSize;
        TotalPages = totalPages;
    }

    public T[] Items { get; set; } = Array.Empty<T>();

    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}