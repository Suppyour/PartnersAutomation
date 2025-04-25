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

    // [HttpPost]
    // public async Task<ActionResult<Guid>> CreateProduct(ProductRequest productRequest)
    // {
    //     var (product, error) = Models.Product.CreateProduct(
    //         Guid.NewGuid(),
    //         productRequest.,
    //         request.Email,
    //         request.Password);
    //     if (!string.IsNullOrEmpty(error))
    //     {
    //         return BadRequest(error);
    //     }
    // }
}