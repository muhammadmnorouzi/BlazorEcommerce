using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Components.Products;

public partial class ProductItem
{
    [Parameter]
    public bool ShowLinks { get; set; } = true;

    [Parameter]
    public Product Product { get; set; } = null!;

    private string GetPriceText(Product product)
    {
        var variants = product.Variants;

        if (variants.Count == 0)
        {
            return string.Empty;
        }

        if (variants.Count == 1)
        {
            return $"{String.Format("{0:C}", variants[0].Price)}";
        }

        decimal minPrice = variants.Min(v => v.Price);
        return $"Starting at {String.Format("{0:C}", minPrice)}";
    }
}
