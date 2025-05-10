namespace Backend.Contracts;

public class PaymentResponse
{
    public string ConfirmationUrl { get; set; }
    public string PaymentId { get; set; }
    
    public string Status { get; set; }
}
