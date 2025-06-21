using Backend.DTOrders;
using Backend.Entities;

namespace Backend.Abstractions;

public interface IOrderRepository
{
    Task Create(Order order);
    Task<List<Order>> GetAll();
    Task<List<Order>> GetByUserId(Guid userId);
    Task<Order?> GetById(Guid orderId);
    Task Delete(Guid orderId);
}