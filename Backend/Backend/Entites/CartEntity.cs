namespace Backend.Entites;

public class CartEntity
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    
    
    public UserEntity? User { get; set; }
    // product entity
}