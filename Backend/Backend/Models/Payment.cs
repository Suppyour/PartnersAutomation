namespace Backend.Models;

public class Payment
{
    public Guid Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string YooKassaPaymentId { get; set; } = string.Empty;
    public string? Status { get; set; } = "Pending"; // Инициализация по умолчанию
    
    public DateTime CreatedAt { get; set; }

    private Payment(Guid id, int orderId, decimal amount, string yooKassaPaymentId, string status, DateTime createdAt)
    {
        Id = id;
        OrderId = orderId;
        Amount = amount;
        YooKassaPaymentId = yooKassaPaymentId;
        Status = status;
        CreatedAt = createdAt;
    }

    public static Payment Create(Guid id, int orderId, decimal amount, string yooKassaPaymentId, string? status, DateTime createdAt)
        => new(id, orderId, amount, yooKassaPaymentId, status ?? "Pending", createdAt);
}