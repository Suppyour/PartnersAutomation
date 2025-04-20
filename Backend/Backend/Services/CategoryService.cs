using Backend.Abstractions;
using Backend.Models;

namespace Backend.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<List<Category>> GetCategories()
    {
        return await _categoryRepository.GetCategory();
    }

    public async Task<Guid> CreateCategory(Category category)
    {
        return await _categoryRepository.CreateCategory(category);
    }

    public async Task<Guid> UpdateCategory(Guid id, string name, string description)
    {
        return await _categoryRepository.UpdateCategory(id, name, description);
    }

    public async Task<Guid> DeleteCategory(Guid id)
    {
        return await _categoryRepository.DeleteCategory(id);
    }
}