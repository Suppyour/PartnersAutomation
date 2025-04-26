namespace Backend.Contracts;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public string Category { get; set; } = null!;
    public List<string> ImageUrls { get; set; } = new();

    public int StockQuantity { get; set; }
}

