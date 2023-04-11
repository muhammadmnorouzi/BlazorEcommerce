namespace Server.Services.CategoryService;

public interface ICategoryService
{
    Task<ServiceResponse<IEnumerable<Category>>> GetCategories();
}