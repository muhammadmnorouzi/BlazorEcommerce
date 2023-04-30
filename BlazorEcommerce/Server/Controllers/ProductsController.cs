using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int id)
    {
        var response = await _productService.GetProduct(id);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<IEnumerable<Product>>>> GetProducts()
    {
        var response = await _productService.GetProducts();

        return Ok(response);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<IEnumerable<Product>>>> GetFeaturedProducts()
    {
        var response = await _productService.GetFeaturedProducts();

        return Ok(response);
    }

    [HttpGet("category/{categoryUrl}")]
    public async Task<ActionResult<ServiceResponse<IEnumerable<Product>>>> GetProductsByCategory(string categoryUrl)
    {
        var response = await _productService.GetProductsByCategory(categoryUrl);

        return Ok(response);
    }

    [HttpGet("search/{searchText}")]
    public async Task<ActionResult<ServiceResponse<PaginationResult<Product>>>> SearchProducts(
        [FromQuery] ProductPaginationParams paginationParams)
    {
        var response = await _productService.SearchProducts(paginationParams);

        return Ok(response);
    }

    [HttpGet("searchsuggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<IEnumerable<string>>>> ProductsSearchSuggestions(string searchText)
    {
        var response = await _productService.GetProductsSearchSuggestions(searchText);

        return Ok(response);
    }
}
