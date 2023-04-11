using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<IEnumerable<Category>>>> GetCategories()
    {
        var result = await _categoryService.GetCategories();

        return Ok(result);
    }
}