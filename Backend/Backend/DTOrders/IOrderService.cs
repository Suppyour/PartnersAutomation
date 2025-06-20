using Backend.Entities;

namespace Backend.DTOrders;

public interface IOrderService
{
    Task<Guid> CreateOrder(Guid userId, List<CartItem> cartItems);
}
