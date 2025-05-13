using Backend.Entities;

namespace Backend.Abstractions.Size;

public interface ISizeRepository
{
    Task AddSizesToProductAsync(Guid productId, List<ProductSizeEntity> sizes);
    Task UpdateProductSizesAsync(Guid productId, List<ProductSizeEntity> sizes);
    Task<List<ProductSizeEntity>> GetProductSizesAsync(Guid productId);
}