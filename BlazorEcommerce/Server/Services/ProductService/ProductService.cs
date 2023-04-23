using System.Reflection.Metadata.Ecma335;
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
            .Include(p => p.Variants)
            .ThenInclude(pv => pv.ProductType)
            .SingleOrDefaultAsync(p => p.Id == id);

        bool success = product != null;
        string message = success ? string.Empty : "Product not found";

        return new ServiceResponse<Product>(product, success, message);
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context
            .Products
            .Include(p => p.Variants)
            .ToArrayAsync();

        return new ServiceResponse<IEnumerable<Product>>(products);
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> GetProductsByCategory(string categoryUrl)
    {
        var products = await _context
            .Products
            .Where(
                p => p.Category!
                    .Url
                    .ToLower()
                    .Equals(categoryUrl.ToLower()))
            .Include(p => p.Variants)
            .ToArrayAsync();

        return new ServiceResponse<IEnumerable<Product>>(data: products);
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> SearchProducts(string searchText)
    {
        var result = await _context
            .Products
            .Where(
                p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                p.Description.ToLower().Contains(searchText.ToLower()))
            .Include(p => p.Variants)
            .ToArrayAsync();

        return new ServiceResponse<IEnumerable<Product>>(result);
    }
}