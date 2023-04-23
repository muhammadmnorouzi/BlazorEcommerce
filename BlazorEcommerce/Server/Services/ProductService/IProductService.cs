namespace Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<IEnumerable<Product>>> GetProducts();
    Task<ServiceResponse<Product>> GetProduct(int id);
    Task<ServiceResponse<IEnumerable<Product>>> GetProductsByCategory(string categoryUrl);
    Task<ServiceResponse<IEnumerable<Product>>> SearchProducts(string searchText);
    Task<ServiceResponse<IEnumerable<string>>> GetProductsSearchSuggestions(string searchText);
}