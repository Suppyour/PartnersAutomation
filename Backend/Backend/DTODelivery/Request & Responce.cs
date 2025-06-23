namespace Backend.DTODelivery;

public class DeliveryRequest
{
    public string DeliveryMethod { get; set; }
    public string Address { get; set; }
}

public class DeliveryResponse
{
    public Guid Id { get; set; }
    public string DeliveryMethod { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public string Status { get; set; }
}
