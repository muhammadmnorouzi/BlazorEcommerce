using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductItem
{
    [Parameter]
    public bool ShowLinks { get; set; } = true;

    [Parameter]
    public Product Product { get; set; } = null!;
}
