using Backend.Abstractions;
using Backend.Entites;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDbContext _context;

        public CategoryRepository(CategoryDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategory()
        {
            var categoryEntity = await _context.Categories
                .AsNoTracking()
                .ToListAsync();
            var categories = categoryEntity
                .Select(c => Category.CreateCategory(c.Id, c.Name, c.Description).Category)
                .ToList();
            return categories;
        }  

        public async Task<Guid> CreateCategory(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
            };
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            
            return categoryEntity.Id;
        }

        public async Task<Guid> UpdateCategory(Guid id, string name, string description)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setProperty => setProperty
                    .SetProperty(c => c.Id, c => id)
                    .SetProperty(c => c.Name, c => name)
                    .SetProperty(c => c.Description, c => description));
            return id;
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}