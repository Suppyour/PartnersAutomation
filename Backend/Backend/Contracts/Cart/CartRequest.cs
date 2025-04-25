using Backend.Models;

namespace Backend.Contracts;

public record CartRequest(
    Guid UserId,
    Guid ProductId,
    int Quantity
);