namespace Client.Services.CategoryService;

public interface ICategoryService
{
    Category[] Categories { get; set; }
    Task GetCategories();
}