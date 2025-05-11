using Backend.Abstractions.Payment;
using Backend.Entites;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly MyDbContext _context;

    public PaymentRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Payment payment)
    {
        var entity = new PaymentEntity
        {
            Id = payment.Id,
            OrderId = payment.OrderId,
            Amount = payment.Amount,
            YooKassaPaymentId = payment.YooKassaPaymentId,
            Status = payment.Status ?? "Pending",
            CreatedAt = payment.CreatedAt
        };

        await _context.Payments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Payment?> GetByYooKassaIdAsync(string yooKassaPaymentId)
    {
        var entity = await _context.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.YooKassaPaymentId == yooKassaPaymentId);

        if (entity == null)
            return null;

        return Payment.Create(
            entity.Id,
            entity.OrderId,
            entity.Amount,
            entity.YooKassaPaymentId,
            entity.Status,
            entity.CreatedAt);
    }

    public async Task UpdateStatusAsync(string yooKassaPaymentId, string status)
    {
        await _context.Payments
            .Where(p => p.YooKassaPaymentId == yooKassaPaymentId)
            .ExecuteUpdateAsync(setProperty => setProperty
                .SetProperty(p => p.Status, status));
    }
}