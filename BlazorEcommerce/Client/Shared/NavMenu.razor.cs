using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared;

public partial class NavMenu
{
    [Inject]
    public ICategoryService CategoryService { get; set; } = null!;
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await CategoryService.GetCategories();
    }
}