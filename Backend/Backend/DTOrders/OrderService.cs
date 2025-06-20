using Backend.Abstractions;
using Backend.Entities;

namespace Backend.DTOrders;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> CreateOrder(Guid userId, List<CartItem> cartItems)
    {
        var orderId = await _orderRepository.CreateOrder(userId, cartItems);
        return orderId;
    }
}
