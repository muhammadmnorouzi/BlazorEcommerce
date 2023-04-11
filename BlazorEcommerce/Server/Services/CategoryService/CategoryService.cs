using BlazorEcommerce.Server.Data;

namespace Server.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;
    public CategoryService(DataContext context)
    {
        this._context = context;
    }

    public async Task<ServiceResponse<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _context.Categories.ToArrayAsync();

        return new ServiceResponse<IEnumerable<Category>>(categories);
    }
}