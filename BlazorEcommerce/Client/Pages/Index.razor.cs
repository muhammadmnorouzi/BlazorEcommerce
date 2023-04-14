using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Parameter]
    public string? CategoryUrl { get; set; }

    [Inject]
    public IProductService ProductService { get; set; } = null!;

    protected async override Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        await ProductService.GetProducts(CategoryUrl);
    }
}