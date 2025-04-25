namespace Backend.Contracts;

public record ProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    string Category
    );