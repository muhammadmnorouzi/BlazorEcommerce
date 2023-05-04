using BlazorEcommerce.Client.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Parameter]
    public string? CategoryUrl { get; set; }

    [Parameter]
    public string? SearchText { get; set; }

    [Parameter]
    public int Page { get; set; } = 1;

    [Inject]
    public IProductService ProductService { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    protected async override Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (SearchText == null)
        {
            await ProductService.GetProducts(CategoryUrl);
        }
        else
        {
            await ProductService.SearchProducts(new ProductPaginationParams
            {
                PageNumber = Page,
                PageSize = ProductService.SearchPaginationHeader?.ItemsPerPage ?? 2,
                SearchText = SearchText,
            });
        }
    }

    private void PageChanged(int page)
    {
        NavigationManager.NavigateTo($"/search/{SearchText}/{page}");
    }
}