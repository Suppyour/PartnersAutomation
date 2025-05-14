using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Backend.Entities;

namespace Backend.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public List<ProductImageEntity>? Images { get; set; }
        public string? SizesJson { get; set; }

        [NotMapped]
        public Dictionary<string, int> Sizes
        {
            get => string.IsNullOrEmpty(SizesJson) 
                ? new Dictionary<string, int>() 
                : JsonSerializer.Deserialize<Dictionary<string, int>>(SizesJson)!;
            set => SizesJson = JsonSerializer.Serialize(value);
        }

        public static (Product? Product, string Error) CreateProduct(string name, string description, decimal price,
            string category, Dictionary<string, int>? sizes = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                return (null, "Название не может быть пустым.");

            if (price < 10)
                return (null, "Минимальная цена товара должна быть больше.");

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                CreatedAt = DateTime.UtcNow
            };

            if (sizes != null)
            {
                product.Sizes = sizes;
            }

            return (product, string.Empty);
        }
    }
}