namespace Backend.DTOrders;

public class OrderItemEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Guid OrderId { get; set; }
    public OrderEntity Order { get; set; }
}
