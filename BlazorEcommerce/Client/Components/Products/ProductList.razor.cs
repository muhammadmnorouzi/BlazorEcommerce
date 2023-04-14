using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductList : IDisposable
{
    [Inject]
    public IProductService ProductService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        ProductService.ProductsChanged += StateHasChanged;

        await ProductService.GetProducts();
    }

    public void Dispose()
    {
        ProductService.ProductsChanged -= StateHasChanged;
    }
}
