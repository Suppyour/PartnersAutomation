namespace Backend.Contracts.Size;

public record ProductSizeResponse
{
    public string SizeName { get; set; } = null!;
    public int Quantity { get; set; }
}