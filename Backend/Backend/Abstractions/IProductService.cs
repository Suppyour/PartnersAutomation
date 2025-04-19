using Backend.Models;

namespace Backend.Abstractions;

public interface IProductService
{
    Task<Guid> CreateProduct(Category category);

    Task<Guid> DeleteProduct(Guid id);

    Task<List<Category?>> GetProducts();

    Task<Guid> UpdateProducts(Guid id, string name, string description);
}