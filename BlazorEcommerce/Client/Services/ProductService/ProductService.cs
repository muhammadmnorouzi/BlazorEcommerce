using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private readonly NavigationManager _navigationManager;
    private readonly ILogger<ProductService> _logger;

    private string _lastSearchText = string.Empty;

    public ProductService(
        HttpClient client,
        NavigationManager navigationManager,
        ILogger<ProductService> logger)
    {
        this._navigationManager = navigationManager;
        _logger = logger;
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
        var result = await _client.GetFromJsonAsync<ServiceResponse<string[]>>(
            $"api/products/searchsuggestions/{searchText}");

        return result!.Data!;
    }

    public async Task SearchProducts(ProductPaginationParams paginationParams)
    {
        if (_lastSearchText == paginationParams.SearchText)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(paginationParams.SearchText))
        {
            _navigationManager.NavigateTo("/");
            return;
        }

        var httpResponse = await _client.PostAsJsonAsync("api/products/search/", paginationParams);

        if (httpResponse.IsSuccessStatusCode == false)
        {
            Message = await httpResponse.Content.ReadAsStringAsync() ?? "Error in api call for search !!!";
            Products = Array.Empty<Product>();
        }
        else
        {
            var result = await httpResponse.Content.ReadFromJsonAsync<ServiceResponse<PaginationResult<Product>>>();

            if (result != null && result.Data != null)
            {
                Products = result.Data.Items;

                _logger.LogInformation($"{Products.Length} items found with this searchText");

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
        }

        ProductsChanged?.Invoke();
    }
}