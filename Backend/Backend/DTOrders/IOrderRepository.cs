using Backend.Entities;

namespace Backend.Abstractions;

public interface IOrderRepository
{
    Task<Guid> CreateOrder(Guid userId, List<CartItem> cartItems);
}