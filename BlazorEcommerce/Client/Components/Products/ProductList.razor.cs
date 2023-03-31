using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductList
{
    [Inject] public HttpClient httpClient { get; set; } = null!;
    private static List<Product>? Products;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Products = await httpClient.GetFromJsonAsync<List<Product>>("api/products");
    } 
}
