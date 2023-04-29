namespace Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    Product[] Products { get; set; }
    string Message { get; set; }
    Task GetProducts(string? categoryUrl = null);
    Task SearchProducts(string searchText);
    Task<string[]> GetProductSearchSuggestions(string searchText);
    Task<ServiceResponse<Product>> GetProduct(int id);
}