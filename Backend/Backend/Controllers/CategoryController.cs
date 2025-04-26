using Backend.Abstractions;
using Backend.Contracts;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

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

    [HttpGet]
    public async Task<ActionResult<List<CategoryResponce>>> GetCategories()
    {
        var categories = await _categoryService.GetCategories();

        var responce = categories.Select(c => new CategoryResponce(c.Id, c.Name, c.Description));

        return Ok(responce);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryRequest request)
    {
        var categoryId = await _categoryService.UpdateCategory(id, request.Name, request.Description);

        return Ok(categoryId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteCategory([FromRoute] Guid id)
    {
        return Ok(await _categoryService.DeleteCategory(id));
    }
}