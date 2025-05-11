namespace Backend.Entites;

public class ProductImageEntity
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
