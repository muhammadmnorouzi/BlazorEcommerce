using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace BlazorEcommerce.Client.Shared;

public partial class Search
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    public IProductService ProductService { get; set; } = default!;

    private string searchText = string.Empty;
    private string[] suggestions = Array.Empty<string>();
    protected MudAutocomplete<string>? searchInput = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await searchInput!.FocusAsync();
        }
    }

    public void OnTextChanged(string value)
    {
        Console.WriteLine(value);
    }

    public void SearchProducts()
    {

        NavigationManager.NavigateTo($"search/{searchInput!.Text}");
    }

    public async Task HandleSearch(KeyboardEventArgs args)
    {
        if (args.Key == null || args.Key.Equals("Enter"))
        {
            SearchProducts();
        }
        else if (searchText.Length > 2)
        {
            suggestions = await ProductService.GetProductSearchSuggestions(searchText);
        }
    }

    public async Task<IEnumerable<string>> SearchSuggestions(string searchTxt)
    {
        if (searchTxt.Length > 2)
        {
            return await ProductService.GetProductSearchSuggestions(searchTxt);
        }

        return Array.Empty<string>();
    }

}