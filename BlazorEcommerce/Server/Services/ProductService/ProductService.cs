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

    public async Task<ServiceResponse<IEnumerable<string>>> GetProductsSearchSuggestions(string searchText)
    {
        var products = await FindProductsBySearchText(searchText);

        List<string> result = new List<string>();

        foreach (var product in products)
        {
            if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(product.Title);
            }

            if (product.Description != null)
            {
                var punctuations = product.Description
                    .Where(char.IsPunctuation)
                    .Distinct()
                    .ToArray();

                var words = product.Description
                    .Split()
                    .Select(w => w.Trim(punctuations));

                foreach (string word in words)
                {
                    if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) &&
                        !result.Contains(word))
                    {
                        result.Add(word);
                    }
                }
            }
        }

        return new ServiceResponse<IEnumerable<string>>(result);
    }

    public async Task<ServiceResponse<IEnumerable<Product>>> SearchProducts(string searchText)
    {
        var result = await FindProductsBySearchText(searchText);

        return new ServiceResponse<IEnumerable<Product>>(result);
    }

    private async Task<IEnumerable<Product>> FindProductsBySearchText(string searchText)
    {
        return await _context
             .Products
             .Where(
                 p => p.Title.ToLower().Contains(searchText.ToLower()) ||
                 p.Description.ToLower().Contains(searchText.ToLower()))
             .Include(p => p.Variants)
             .ToArrayAsync();
    }
}