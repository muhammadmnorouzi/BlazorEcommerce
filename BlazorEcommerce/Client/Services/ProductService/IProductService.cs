namespace Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    Product[] Products { get; set; }
    string Message { get; set; }
    PaginationHeader? SearchPaginationHeader { get; set; }
    Task GetProducts(string? categoryUrl = null);
    Task SearchProducts(ProductPaginationParams paginationParams);
    Task<string[]> GetProductSearchSuggestions(string searchText);
    Task<ServiceResponse<Product>> GetProduct(int id);
}