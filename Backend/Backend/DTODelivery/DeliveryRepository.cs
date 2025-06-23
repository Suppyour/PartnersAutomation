using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.DTODelivery;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly MyDbContext _context;

    public DeliveryRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<DeliveryEntity> CreateAsync(DeliveryEntity delivery)
    {
        _context.Deliveries.Add(delivery);
        await _context.SaveChangesAsync();
        return delivery;
    }

    public async Task<DeliveryEntity?> GetByOrderIdAsync(Guid orderId)
    {
        return await _context.Deliveries.FirstOrDefaultAsync(d => d.OrderId == orderId);
    }

    public async Task UpdateStatusAsync(Guid deliveryId, string newStatus)
    {
        var delivery = await _context.Deliveries.FindAsync(deliveryId);
        if (delivery != null)
        {
            delivery.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }
}
