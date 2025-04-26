namespace Backend.Entites;

public class ProductImageEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Url { get; set; } = null!;
    public bool IsMain { get; set; } // Главное фото
}
