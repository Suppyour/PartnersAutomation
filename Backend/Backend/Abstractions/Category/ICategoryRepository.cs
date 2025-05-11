using Backend.Models;

namespace Backend.Abstractions;

public interface ICategoryRepository
{
    Task<Guid> CreateCategory(Category category);

    Task<Guid> DeleteCategory(Guid id);

    Task<List<Category>> GetCategory();

    Task<Guid> UpdateCategory(Guid id, string name, string description);
    
    Task<Category> GetCategoryById(Guid id);
}