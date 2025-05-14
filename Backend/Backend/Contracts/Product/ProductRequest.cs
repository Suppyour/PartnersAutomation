namespace Backend.Contracts
{
    public record ProductRequest(
        string Name,
        string Description,
        decimal Price,
        string Category,
        List<ProductSizeRequest>? Sizes);
}

public record ProductSizeRequest(
    Guid SizeId,
    int Quantity);