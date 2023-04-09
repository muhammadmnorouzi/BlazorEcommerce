using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductItem
{
    [Parameter]
    public Product Product { get; set; } = null!;
}
