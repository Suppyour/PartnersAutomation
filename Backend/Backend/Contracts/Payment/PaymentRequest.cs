namespace Backend.Contracts;

public class PaymentRequest
{
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
}