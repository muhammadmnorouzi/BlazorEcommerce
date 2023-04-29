using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorEcommerce.Client.Shared;

public partial class ShopNavMenu
{
    [Inject]
    public ICategoryService CategoryService { get; set; } = null!;

    private bool open;
    private Anchor anchor;

    void OpenDrawer(Anchor anchor)
    {
        open = true;
        this.anchor = anchor;
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await CategoryService.GetCategories();
    }
}