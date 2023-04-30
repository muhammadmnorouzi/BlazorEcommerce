using System.Net.Http.Json;
using BlazorEcommerce.Shared.Extensions;
using Microsoft.AspNetCore.Components;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private readonly NavigationManager _navigationManager;

    public ProductService(HttpClient client, NavigationManager navigationManager)
    {
        this._navigationManager = navigationManager;
        this._client = client;
        Products = Array.Empty<Product>();
    }

    public Product[] Products { get; set; }
    public string Message { get; set; } = "Products are loading ...";
    public PaginationHeader? SearchPaginationHeader { get; set; }

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
        {
            Products = result.Data;
        }

        ProductsChanged?.Invoke();
    }

    public async Task<string[]> GetProductSearchSuggestions(string searchText)
    {
        var result = await _client.GetFromJsonAsync<ServiceResponse<string[]>>($"api/products/searchsuggestions/{searchText}");

        return result!.Data!;
    }

    public async Task SearchProducts(ProductPaginationParams paginationParams)
    {
        var url = new Uri(_navigationManager.Uri).Host + "/api/products/search/";
        var builder = new UriBuilder(url);

        builder.AddQuery(name: nameof(paginationParams.PageNumber), paginationParams.PageNumber.ToString());
        builder.AddQuery(name: nameof(paginationParams.PageSize), paginationParams.PageSize.ToString());
        builder.AddQuery(name: nameof(paginationParams.SearchText), paginationParams.SearchText);

        var result = await _client.GetFromJsonAsync<ServiceResponse<PaginationResult<Product>>>(builder.Uri);

        if (result != null && result.Data != null)
        {
            Products = result.Data.Items.ToArray();

            SearchPaginationHeader = new PaginationHeader(
                result.Data.CurrentPage,
                result.Data.ItemsPerPage,
                result.Data.TotalItems,
                result.Data.TotalPages);

            if (Products.Length == 0)
            {
                Message = "No Products Found!";
            }
        }

        ProductsChanged?.Invoke();
    }
}