using Backend.Abstractions;
using Backend.DTOrders;
using Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _db;

    public OrderRepository(MyDbContext db)
    {
        _db = db;
    }

    public async Task<Guid> CreateOrder(Guid userId, List<CartItem> cartItems)
    {
        var order = new OrderEntity
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Items = cartItems.Select(c => new OrderItemEntity
            {
                Id = Guid.NewGuid(),
                ProductId = c.ProductId,
                Quantity = c.Quantity
            }).ToList()
        };
        return order.Id;
    }
}