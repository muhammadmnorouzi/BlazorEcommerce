using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages.Products;

public partial class ProductDetail
{
    [Inject]
    public IProductService ProductService { get; set; } = null!;

    [Parameter]
    public int Id { get; set; }

    private Product? Product;
    private string? Message = "Loading Product ....";

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        var result = await ProductService.GetProduct(Id);

        if (result.Success)
        {
            Product = result.Data;
        }
        else
        {
            Message = result.Message;
        }
    }
}