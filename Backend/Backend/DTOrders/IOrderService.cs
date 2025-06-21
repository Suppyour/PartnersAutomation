using Backend.Entities;

namespace Backend.DTOrders;

public interface IOrderService
{
    Task<Guid> CreateOrder(Guid userId, List<CartItem> cartItems);
    Task<List<OrderResponse>> GetAllOrders();
    Task<List<OrderResponse>> GetUserOrders(Guid userId);
    Task<OrderResponse?> GetOrderById(Guid orderId);
    Task DeleteOrder(Guid orderId);
}

