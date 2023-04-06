namespace Client.Services.ProductService;

public interface IProductService
{
    public Product[] Products { get; protected set; }
    Task GetProducts();
}