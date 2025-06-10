namespace Backend.Contracts;

public record ProductRequest(
    string Name,
    string Description,
    decimal Price,
    string Category,
    int Size
);
