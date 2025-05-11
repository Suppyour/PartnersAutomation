using Backend.Models;

namespace Backend.Abstractions.Payment;

public interface IPaymentRepository
{
    Task SaveAsync(Models.Payment payment);
    Task<Models.Payment?> GetByYooKassaIdAsync(string yooKassaPaymentId);
    Task UpdateStatusAsync(string yooKassaPaymentId, string status);
}