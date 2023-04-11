namespace Client.Services.ProductService;

public interface IProductService
{
    Product[] Products { get; set; }
    Task GetProducts();
    Task<ServiceResponse<Product>> GetProduct(int id);
}