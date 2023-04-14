using Microsoft.AspNetCore.Components;
using Shared;

namespace BlazorEcommerce.Client.Pages.Products;

public partial class ProductDetail
{
    [Inject]
    public IProductService ProductService { get; set; } = null!;

    [Parameter]
    public int Id { get; set; }

    private Product Product = null!;
    private int currentTypeId = 1;
    private string? Message = "Loading Product ....";

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        var result = await ProductService.GetProduct(Id);

        if (result.Success && result.Data != null)
        {
            Product = result.Data;
            if (Product.Variants.Count > 0)
            {
                currentTypeId = Product.Variants[0].ProductTypeId;
            }
        }
        else
        {
            Message = result.Message;
        }
    }

    private ProductVariant? GetSelectedVariant()
    {
        return Product
            .Variants
            .FirstOrDefault(v => v.ProductTypeId == currentTypeId);
    }
}