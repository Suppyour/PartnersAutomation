namespace Backend.Entities;

public class PaymentEntity
{
    public Guid Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string YooKassaPaymentId { get; set; }
    public string Status { get; set; } = "Pending..."; // Заглушка пока что
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}