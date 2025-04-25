using Backend.Entites;

namespace Backend.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public string Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public List<ProductImageEntity>? Images { get; set; }

    public static (Product? Product, string Error) CreateProduct(string name, string description, decimal price, int stockQuantity, string category)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (null, "Название не может быть пустым.");

        if (price < 10)
            return (null, "Минимальная цена товара должна быть больше.");

        if (stockQuantity < 0)
            return (null, "Количество на складе не может быть отрицательным.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity,
            Category = category,
            CreatedAt = DateTime.UtcNow
        };

        return (product, string.Empty);
    }
}