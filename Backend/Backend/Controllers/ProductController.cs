using Backend.Abstractions;
using Backend.Abstractions.Size;
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
    private readonly ISizeService _sizeService;

    public ProductController(
        IProductService productService,
        ISizeService sizeService)
    {
        _productService = productService;
        _sizeService = sizeService;
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

        // Добавляем размеры если они есть
        if (productRequest.Sizes?.Any() == true)
        {
            await _sizeService.AddSizesToProduct(productId, productRequest.Sizes);
        }

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
            var sizes = await _sizeService.GetProductSizes(product.Id) ?? new List<ProductSizeEntity>();
        
            response.Add(new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new(),
                Sizes = sizes.Select(s => new ProductSizeResponse
                {
                    SizeName = s.Size?.Name ?? string.Empty,
                    Quantity = s.Quantity
                }).ToList()
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

        var sizes = await _sizeService.GetProductSizes(id) ?? new List<ProductSizeEntity>();

        return Ok(new ProductWithSizesResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new(),
            Sizes = sizes.Select(s => new ProductSizeResponse
            {
                SizeName = s.Size?.Name ?? string.Empty,
                Quantity = s.Quantity
            }).ToList()
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
        if (request.Sizes != null)
        {
            await _sizeService.UpdateProductSizes(id, request.Sizes);
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
            var sizes = await _sizeService.GetProductSizes(product.Id);
            response.Add(new ProductWithSizesResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ImageUrls = product.Images?.Select(i => i.Url).ToList() ?? new(),
                Sizes = sizes.Select(s => new ProductSizeResponse
                {
                    SizeName = s.Size.Name,
                    Quantity = s.Quantity
                }).ToList()
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