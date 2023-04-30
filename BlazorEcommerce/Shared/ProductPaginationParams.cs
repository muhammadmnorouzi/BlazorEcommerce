namespace BlazorEcommerce.Shared;

public class ProductPaginationParams : PaginationParams
{
    public string SearchText { get; set; } = string.Empty;
}