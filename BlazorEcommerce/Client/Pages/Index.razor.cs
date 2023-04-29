using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Parameter]
    public string? CategoryUrl { get; set; }

    [Parameter]
    public string? SearchText { get; set; }

    [Inject]
    public IProductService ProductService { get; set; } = null!;

    protected async override Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (SearchText == null)
        {
            await ProductService.GetProducts(CategoryUrl);
        }
        else
        {
            await ProductService.SearchProducts(SearchText);
        }
    }
}