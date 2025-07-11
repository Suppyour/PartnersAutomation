using Backend.Abstractions;
using Backend.Entities;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class ProductRepository(MyDbContext context) : IProductRepository
{
    public async Task<List<Product?>> GetProducts()
    {
        var productEntities = await context.Products
            .Include(p => p.Images)
            .AsNoTracking()
            .ToListAsync();

        var products = productEntities
            .Select(p =>
            {
                var (product, _) = Product.CreateProduct(
                    p.Name,
                    p.Description,
                    p.Price,
                    p.Category
                );

                if (product != null)
                {
                    product.Id = p.Id;
                    product.CreatedAt = p.CreatedAt;
                    product.UpdatedAt = p.UpdatedAt;
                    product.Images = p.Images?.ToList();
                }

                return product;
            })
            .ToList();

        return products;
    }

    public async Task<Guid> CreateProduct(Product? product)
    {
        var entity = new ProductEntity
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            CreatedAt = product.CreatedAt
        };

        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<Guid> UpdateProduct(Guid id, string name, string description, decimal price, int stockQuantity,
        string category)
    {
        await context.Products
            .Where(p => p.Id == id)
            .ExecuteUpdateAsync(setProperty => setProperty
                .SetProperty(p => p.Name, p => name)
                .SetProperty(p => p.Description, p => description)
                .SetProperty(p => p.Price, p => price)
                .SetProperty(p => p.Category, p => category)
                .SetProperty(p => p.UpdatedAt, p => DateTime.UtcNow));
        return id;
    }

    public async Task<Guid> DeleteProduct(Guid id)
    {
        await context.Products
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
    
    public async Task<List<Product>> SearchProductsByName(string name)
    {
        var productEntities = await context.Products
            .Include(p => p.Images)
            .Where(p => p.Name.Contains(name))
            .AsNoTracking()
            .ToListAsync();

        return productEntities
            .Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Images = p.Images?.ToList()
            })
            .ToList();
    }
    
}