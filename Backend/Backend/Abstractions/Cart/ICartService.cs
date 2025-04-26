using Backend.Models;

namespace Backend.Abstractions;

public interface ICartService
{
    Task<List<CartItem>> GetCart(Guid userId);
    Task<Guid> CreateCart(CartItem cartItem);
    Task<Guid> RemoveFromCart(Guid userId, Guid productId);
    Task<Guid> ClearCart(Guid userId);
}