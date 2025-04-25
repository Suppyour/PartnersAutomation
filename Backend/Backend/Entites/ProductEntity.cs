namespace Backend.Entites;

public class ProductEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public List<ProductImageEntity> Images { get; set; } = new();
}
