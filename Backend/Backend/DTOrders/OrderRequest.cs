namespace Backend.DTOrders;

public record OrderRequest(Guid UserId, List<Guid> CartItemIds);

public class OrderResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

