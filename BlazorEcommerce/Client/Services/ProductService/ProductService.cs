using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _client;

    public ProductService(HttpClient client)
    {
        this._client = client;
        Products = Array.Empty<Product>();
    }

    public Product[] Products { get; set; }
    public string Message { get; set; } = "Products are loading ...";

    public event Action ProductsChanged = new Action(() => { });

    public async Task<ServiceResponse<Product>> GetProduct(int id)
    {
        var result = await _client
            .GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{id}");

        result ??= new ServiceResponse<Product>(null, false, "Api call failed ...");

        return result;
    }

    public async Task GetProducts(string? categoryUrl = null)
    {
        var result = categoryUrl == null
        ? await _client.GetFromJsonAsync<ServiceResponse<Product[]>>("api/products")
        : await _client.GetFromJsonAsync<ServiceResponse<Product[]>>($"api/products/category/{categoryUrl}");

        if (result != null && result.Data != null)
            Products = result.Data;

        ProductsChanged?.Invoke();
    }

    public async Task<string[]> GetProductSearchSuggestions(string searchText)
    {
        var result = await _client.GetFromJsonAsync<ServiceResponse<string[]>>($"api/products/searchsuggestions/{searchText}");

        return result!.Data!;
    }

    public async Task SearchProducts(string searchText)
    {
        var result = await _client.GetFromJsonAsync<ServiceResponse<Product[]>>($"api/products/search/{searchText}");

        if (result != null && result.Data != null)
        {
            Products = result.Data;

            if (Products.Length == 0)
            {
                Message = "No Products Found!";
            }
        }

        ProductsChanged?.Invoke();
    }
}