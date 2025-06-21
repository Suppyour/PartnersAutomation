using Backend.Abstractions;
using Backend.Contracts;
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
        var orderItems = cartItems.Select(c => new OrderItem
        {
            ProductId = c.ProductId,
            Quantity = c.Quantity
        }).ToList();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Items = orderItems
        };

        await _orderRepository.Create(order);
        return order.Id;
    }

    public async Task<List<OrderResponse>> GetAllOrders()
    {
        var orders = await _orderRepository.GetAll();
        return orders.Select(MapToResponse).ToList();
    }

    public async Task<List<OrderResponse>> GetUserOrders(Guid userId)
    {
        var orders = await _orderRepository.GetByUserId(userId);
        return orders.Select(MapToResponse).ToList();
    }

    public async Task<OrderResponse?> GetOrderById(Guid orderId)
    {
        var order = await _orderRepository.GetById(orderId);
        return order is null ? null : MapToResponse(order);
    }

    public async Task DeleteOrder(Guid orderId)
    {
        await _orderRepository.Delete(orderId);
    }

    private static OrderResponse MapToResponse(Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            UserId = order.UserId,
            CreatedAt = order.CreatedAt,
            Items = order.Items.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };
    }
}