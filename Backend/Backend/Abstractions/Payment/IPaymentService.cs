using Backend.Contracts;

namespace Backend.Abstractions.Payment;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePaymentAsync(PaymentRequest request);
    Task HandleCallbackAsync(string eventType, string paymentId, string status);
}
