namespace Backend.DTOrders;

public record OrderRequest(
    Guid UserId,
    List<Guid> CartItemIds
);
