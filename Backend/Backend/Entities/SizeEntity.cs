namespace Backend.Entities;

public class SizeEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<ProductSizeEntity> ProductSizes { get; set; } = new();
}