namespace Backend.Contracts;

public record CartResponse(
    Guid Id,
    Guid UserId,
    Guid ProductId,
    int Quantity,
    DateTime AddedAt
);