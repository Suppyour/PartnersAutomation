using Backend.Entites;
using Backend.Models;

namespace Backend.Abstractions;

public interface ICartRepository
{
    Task<CartEntity> AddToCart(CartEntity cartItem);

    Task<Guid> RemoveFromCart(Guid userId, Guid productId);

    Task<List<CartEntity>> GetCart(Guid userId);
    
    Task<Guid> ClearCart(Guid userId);
}