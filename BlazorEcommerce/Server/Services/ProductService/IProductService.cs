
using BlazorEcommerce.Server.Helpers.Pagination;


namespace Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<IEnumerable<Product>>> GetProducts();
    Task<ServiceResponse<IEnumerable<Product>>> GetFeaturedProducts();
    Task<ServiceResponse<Product>> GetProduct(int id);
    Task<ServiceResponse<IEnumerable<Product>>> GetProductsByCategory(string categoryUrl);
    Task<ServiceResponse<PaginationResult<Product>>> SearchProducts(ProductPaginationParams paginationParams);
    Task<ServiceResponse<IEnumerable<string>>> GetProductsSearchSuggestions(string searchText);
}