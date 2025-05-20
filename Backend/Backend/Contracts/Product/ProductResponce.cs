using Backend.Contracts.Size;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = new();
    
    public List<ProductSizeResponse> Sizes { get; set; } = new();
}