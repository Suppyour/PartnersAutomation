namespace Backend.Contracts;

public record ProductRequest(
    Guid productId,
    string name,
    string description,
    decimal price
    );