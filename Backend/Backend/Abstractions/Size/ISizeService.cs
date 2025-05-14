using Backend.Contracts;
using Backend.Entities;

namespace Backend.Abstractions.Size;

public interface ISizeService
{
    Task AddSizesToProduct(Guid productId, List<ProductSizeRequest> sizes);
    Task UpdateProductSizes(Guid productId, List<ProductSizeRequest> sizes);
    Task<List<ProductSizeEntity>> GetProductSizes(Guid productId);
}