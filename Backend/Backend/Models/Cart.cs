using Backend.Models;

public class CartItem
{
    public Guid CardId { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }
    public Product? Product { get; set; }

    public static (CartItem? Cart, string Error) CreateCart(Guid userId, Guid productId, int quantity)
    {
        if (quantity <= 0)
            return (null, "Количество товара должно быть больше нуля.");

        var cart = new CartItem
        {
            CardId = Guid.NewGuid(),
            UserId = userId,
            ProductId = productId,
            Quantity = quantity,
            AddedAt = DateTime.UtcNow
        };

        return (cart, string.Empty);
    }
}