using System.Net.Http.Json;

namespace Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _client;

    public CategoryService(HttpClient client)
    {
        this._client = client;
        Categories = Array.Empty<Category>();
    }

    public Category[] Categories { get; set; }

    public async Task GetCategories()
    {
        var result = await _client
            .GetFromJsonAsync<ServiceResponse<Category[]>>("api/categories");

        if (result != null && result.Data != null)
            Categories = result.Data;
    }
}