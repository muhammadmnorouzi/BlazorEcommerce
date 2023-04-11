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
}
