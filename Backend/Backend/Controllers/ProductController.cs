using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для управления продуктами. Реализует создание, получение, обновление и удаление продуктов.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Конструктор для инициализации контроллера.
    /// </summary>
    /// <param name="productService">Сервис для работы с продуктами.</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Создание нового продукта.
    /// </summary>
    /// <param name="productRequest">Данные для создания нового продукта.</param>
    /// <returns>Идентификатор созданного продукта.</returns>
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

    /// <summary>
    /// Получение списка всех продуктов.
    /// </summary>
    /// <returns>Список продуктов в формате ProductResponse.</returns>
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

    /// <summary>
    /// Обновление данных существующего продукта.
    /// </summary>
    /// <param name="id">Идентификатор продукта, который нужно обновить.</param>
    /// <param name="productRequest">Данные для обновления продукта.</param>
    /// <returns>Идентификатор обновленного продукта.</returns>
    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateProduct([FromRoute] Guid id, [FromBody] ProductRequest productRequest)
    {
        var productId = await _productService.UpdateProducts(id, productRequest.Name, productRequest.Description,
            productRequest.Price, productRequest.StockQuantity, productRequest.Category);

        return Ok(productId);
    }

    /// <summary>
    /// Удаление продукта по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта, который нужно удалить.</param>
    /// <returns>Идентификатор удаленного продукта.</returns>
    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteProduct([FromRoute] Guid id)
    {
        var productId = await _productService.DeleteProduct(id);
        return Ok(productId);
    }
}
