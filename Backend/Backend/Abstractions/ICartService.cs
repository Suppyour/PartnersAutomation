using Backend.Contracts;

namespace Backend.Abstractions;

public interface ICartService
{
    Task<CartResponse> AddToCart(CartRequest request);
    
    Task<Guid> RemoveFromCart(Guid userId, Guid productId);
    
    Task<List<CartResponse>> GetCart(Guid userId);
    
    Task<Guid> ClearCart(Guid userId);
    
}