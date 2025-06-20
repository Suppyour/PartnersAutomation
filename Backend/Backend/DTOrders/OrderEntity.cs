using Backend.DTOrders;

public class OrderEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<OrderItemEntity> Items { get; set; } = new();
}