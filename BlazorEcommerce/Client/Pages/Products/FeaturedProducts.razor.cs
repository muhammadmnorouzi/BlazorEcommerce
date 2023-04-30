using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages.Products;

public partial class FeaturedProducts : IDisposable
{
    [Inject]
    public IProductService ProductService { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ProductService.ProductsChanged += StateHasChanged;
    }

    public void Dispose()
    {
        ProductService.ProductsChanged -= StateHasChanged;
    }
}