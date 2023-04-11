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

    public async Task<ServiceResponse<Product>> GetProduct(int id)
    {
        var result = await _client
            .GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{id}");

        result ??= new ServiceResponse<Product>(null, false, "Api call failed ...");

        return result;
    }

    public async Task GetProducts()
    {
        var result = await _client
            .GetFromJsonAsync<ServiceResponse<Product[]>>("api/products");

        if (result != null && result.Data != null)
            Products = result.Data;
    }
}