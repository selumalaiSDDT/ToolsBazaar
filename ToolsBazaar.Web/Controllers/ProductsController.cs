using Microsoft.AspNetCore.Mvc;
using ToolsBazaar.Domain.ProductAggregate;

namespace ToolsBazaar.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase 
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet("most-expensive")]
    public IActionResult GetMostExpensiveProducts()
    {
        var expensiveProducts = _productRepository.GetAll()
                            .OrderByDescending(p => p.Price)
                            .ThenBy(p => p.Name)
                            .ToList();

        return Ok(expensiveProducts);
    }
}