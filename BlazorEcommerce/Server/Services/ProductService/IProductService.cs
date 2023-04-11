namespace Server.Services.ProductService;

public interface IProductService
{
    Task<ServiceResponse<IEnumerable<Product>>> GetProducts();
    Task<ServiceResponse<Product>> GetProduct(int id);
}