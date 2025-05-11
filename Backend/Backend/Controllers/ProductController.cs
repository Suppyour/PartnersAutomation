using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для управления продуктами. Реализует CRUD-операции, поиск и загрузку изображений.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ProductController"/>.
    /// </summary>
    /// <param name="productService">Сервис для работы с продуктами.</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Создает новый продукт.
    /// </summary>
    /// <param name="productRequest">Данные продукта.</param>
    /// <returns>
    /// Идентификатор созданного продукта.
    /// В случае ошибки валидации возвращает <see cref="BadRequestResult"/> с сообщением.
    /// </returns>
    /// <response code="200">Продукт успешно создан.</response>
    /// <response code="400">Некорректные данные продукта.</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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
    /// Получает список всех продуктов.
    /// </summary>
    /// <returns>Список продуктов с основными данными и ссылками на изображения.</returns>
    /// <response code="200">Успешный запрос.</response>
    [HttpGet]
    [ProducesResponseType(typeof(List<ProductResponse>), StatusCodes.Status200OK)]
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
    /// Обновляет данные продукта.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <param name="productRequest">Новые данные продукта.</param>
    /// <returns>Идентификатор обновленного продукта.</returns>
    /// <response code="200">Продукт успешно обновлен.</response>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> UpdateProduct([FromRoute] Guid id, [FromBody] ProductRequest productRequest)
    {
        var productId = await _productService.UpdateProducts(
            id, 
            productRequest.Name, 
            productRequest.Description,
            productRequest.Price, 
            productRequest.StockQuantity, 
            productRequest.Category
        );

        return Ok(productId);
    }

    /// <summary>
    /// Удаляет продукт по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор продукта.</param>
    /// <returns>Идентификатор удаленного продукта.</returns>
    /// <response code="200">Продукт успешно удален.</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(List<ProductResponse>), StatusCodes.Status200OK)]
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
            StockQuantity = p.StockQuantity,
            ImageUrls = p.Images?.Select(i => i.Url).ToList() ?? new List<string>()
        }).ToList();

        return Ok(response);
    }


}