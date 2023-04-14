namespace Client.Services.ProductService;

public interface IProductService
{
    event Action ProductsChanged;
    Product[] Products { get; set; }
    Task GetProducts(string? categoryUrl = null);
    Task<ServiceResponse<Product>> GetProduct(int id);
}