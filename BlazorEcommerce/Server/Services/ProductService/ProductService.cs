using BlazorEcommerce.Server.Data;

namespace Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        this._context = context;
    }

    public async Task<ServiceResponse<Product>> GetProduct(int id)
    {
        var product = await _context
            .Products
            .SingleOrDefaultAsync(p => p.Id == id);

        bool success = product != null;
        string message = success ? string.Empty : "Product not found";

        return new ServiceResponse<Product>(product, success, message);
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context.Products.ToArrayAsync();

        return new ServiceResponse<IEnumerable<Product>>(products);
    }
}