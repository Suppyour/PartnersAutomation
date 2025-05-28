namespace Backend.Contracts;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    
    public int Size { get; set; }
    public List<string> ImageUrls { get; set; } = new();
}