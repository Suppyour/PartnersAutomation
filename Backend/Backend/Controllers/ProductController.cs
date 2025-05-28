using Backend.Abstractions;
using Backend.Contracts;
using Backend.Contracts.Size;
using Backend.Entities;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(
        IProductService productService)
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
            productRequest.Category);

        if (!string.IsNullOrEmpty(error))
            return BadRequest(error);

        var productId = await _productService.CreateProduct(product);

        return Ok(productId);
    }
    /// <summary>
    /// Получает список всех продуктов.
    /// </summary>
    /// <returns>Список продуктов с основными данными и ссылками на изображения.</returns>
    /// <response code="200">Успешный запрос.</response>
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetProducts()
    {
        var products = await _productService.GetProducts();
    
        var response = new List<ProductResponse>();
        foreach (var product in products)
        {
            response.Add(new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new()
            });
        }

        return Ok(response);
    }

    /// <summary>
    /// Получает продукт с размерами по ID
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductWithSizesResponse>> GetProduct(Guid id)
    {
        var products = await _productService.GetProducts();
        var product = products.FirstOrDefault(p => p?.Id == id);
    
        if (product == null)
            return NotFound();

        return Ok(new ProductWithSizesResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new(),
        });
    }

    /// <summary>
    /// Обновляет продукт и его размеры
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(
        [FromRoute] Guid id,
        [FromBody] ProductRequest request)
    {
        // Обновляем продукт и проверяем, что он существует
        var updatedId = await _productService.UpdateProducts(
            id,
            request.Name,
            request.Description,
            request.Price,
            request.Category);
        
        if (updatedId == Guid.Empty)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Получает все товары с фильтрацией по размеру
    /// </summary>
    /// <param name="size">Фильтр по размеру (опционально)</param>
    [HttpGet("filterSize")]
    public async Task<ActionResult<List<ProductWithSizesResponse>>> GetProducts(
        [FromQuery] string? size = null)
    {
        var products = await _productService.GetProducts();

        var response = new List<ProductWithSizesResponse>();
        foreach (var product in products)
        {
            response.Add(new ProductWithSizesResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new(),
            });
        }

        return Ok(response);
    }
    
    /// <summary>
    /// Удаляет продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Идентификатор удаленного продукта.</returns>
    /// <response code="200">Продукт успешно удален.</response>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteProduct([FromRoute] Guid id)
    {
        var productId = await _productService.DeleteProduct(id);
        return Ok(productId);
    }

    /// <summary>
    /// Ищет продукты по названию (регистронезависимо).
    /// </summary>
    /// <param name="name">Фрагмент названия для поиска.</param>
    /// <returns>Список найденных продуктов.</returns>
    /// <response code="200">Успешный поиск.</response>
    [HttpGet("search")]
    public async Task<ActionResult<List<ProductResponse>>> SearchProducts([FromQuery] string name)
    {
        var products = await _productService.SearchProductsByName(name);

        var response = products.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Category = p.Category,
            ImageUrls = p.Images?.Select(i => i.Url).ToList() ?? new List<string>()
        }).ToList();

        return Ok(response);
    }     
}