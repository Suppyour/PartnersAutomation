using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateProduct(ProductRequest productRequest)
    {
        var (product, error) = Product.CreateProduct(
            productRequest.Name,
            productRequest.Description,
            productRequest.Price,
            productRequest.StockQuantity,
            productRequest.Category
        );

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var productId = await _productService.CreateProduct(product);
        return Ok(productId);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetProducts()
    {
        var products = await _productService.GetProducts();

        var response = products.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Category = p.Category,
            StockQuantity = p.StockQuantity,
            ImageUrls = p.Images?.Select(i => i.Url).ToList() ?? new List<string>()
        }).ToList();


        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateProduct([FromRoute] Guid id, [FromBody] ProductRequest productRequest)
    {
        var productId = await _productService.UpdateProducts(id, productRequest.Name, productRequest.Description,
            productRequest.Price, productRequest.StockQuantity, productRequest.Category);

        return Ok(productId);
    }

    [HttpDelete]

    public async Task<ActionResult<Guid>> DeleteProduct([FromRoute] Guid id)
    {
        var productId = await _productService.DeleteProduct(id);
        return Ok(productId);
    }
}