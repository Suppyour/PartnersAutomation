using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для управления категориями. Реализует создание, получение, обновление и удаление категорий.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Конструктор для инициализации контроллера.
    /// </summary>
    /// <param name="categoryService">Сервис для работы с категориями.</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Создание новой категории.
    /// </summary>
    /// <param name="request">Данные для создания новой категории.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCategory([FromBody] CategoryRequest request)
    {
        var (category, error) = Category.CreateCategory(
            Guid.NewGuid(),
            request.Name,
            request.Description);
        
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var categoryId = await _categoryService.CreateCategory(category);

        return Ok(categoryId);
    }

    /// <summary>
    /// Получение списка всех категорий.
    /// </summary>
    /// <returns>Список категорий в формате CategoryResponce.</returns>
    [HttpGet]
    public async Task<ActionResult<List<CategoryResponce>>> GetCategories()
    {
        var categories = await _categoryService.GetCategories();

        var responce = categories.Select(c => new CategoryResponce(c.Id, c.Name, c.Description));

        return Ok(responce);
    }

    /// <summary>
    /// Обновление данных существующей категории.
    /// </summary>
    /// <param name="id">Идентификатор категории, которую нужно обновить.</param>
    /// <param name="request">Данные для обновления категории.</param>
    /// <returns>Идентификатор обновленной категории.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryRequest request)
    {
        var categoryId = await _categoryService.UpdateCategory(id, request.Name, request.Description);

        return Ok(categoryId);
    }

    /// <summary>
    /// Удаление категории по ее идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории, которую нужно удалить.</param>
    /// <returns>Идентификатор удаленной категории.</returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteCategory([FromRoute] Guid id)
    {
        return Ok(await _categoryService.DeleteCategory(id));
    }
}
