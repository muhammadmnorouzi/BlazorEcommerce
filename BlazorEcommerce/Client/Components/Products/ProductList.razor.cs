using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductList
{
    [Inject] public IProductService ProductService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await ProductService.GetProducts();
    }
}
