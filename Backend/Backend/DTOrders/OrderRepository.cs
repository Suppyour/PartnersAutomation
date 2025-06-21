using Backend.Abstractions;
using Backend.DTOrders;
using Backend.Entities;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _dbContext;

    public OrderRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Order>> GetAll()
    {
        return await _dbContext.Orders
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<List<Order>> GetByUserId(Guid userId)
    {
        return await _dbContext.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.Items)
            .ToListAsync();
    }

    public async Task<Order?> GetById(Guid orderId)
    {
        return await _dbContext.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task Delete(Guid orderId)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);
        if (order != null)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}