namespace Backend.Contracts.Size;

public class ProductWithSizesResponse : ProductResponse
{
    public List<ProductSizeResponse> Sizes { get; set; } = new();
}