using Backend.Entities;

namespace Backend.Abstractions.Cart;

public interface ICartRepository
{
    Task<CartEntity> CreateCart(CartEntity cartItem);

    Task<Guid> RemoveFromCart(Guid userId, Guid productId);

    Task<List<CartEntity>> GetCart(Guid userId);
    
    Task<Guid> ClearCart(Guid userId);
}