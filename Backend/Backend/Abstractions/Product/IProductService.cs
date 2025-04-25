using Backend.Models;

namespace Backend.Abstractions;

public interface IProductService
{
    Task<Guid> CreateProduct(Product? product);

    Task<Guid> DeleteProduct(Guid id);

    Task<List<Product?>> GetProducts();

    Task<Guid> UpdateProducts(Guid id, string name, string description, decimal price, int stockQuantity,
        string category);
}