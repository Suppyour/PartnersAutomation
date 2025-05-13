using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Backend.Entities;

public class ProductEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<ProductImageEntity> Images { get; set; } = new();
    public List<ProductSizeEntity> ProductSizes { get; set; } = new();
    
}