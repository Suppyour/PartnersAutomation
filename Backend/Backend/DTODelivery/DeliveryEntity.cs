namespace Backend.DTODelivery;

public class DeliveryEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public string DeliveryMethod { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
