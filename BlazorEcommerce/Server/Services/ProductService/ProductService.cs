using BlazorEcommerce.Server.Data;

namespace Server.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        this._context = context;
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> GetProductsAsync()
    {
        var products = await _context.Products.ToArrayAsync();

        return new ServiceResponse<IEnumerable<Product>>(products);
    }
}