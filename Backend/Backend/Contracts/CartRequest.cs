using Backend.Models;

namespace Backend.Contracts;

public class CartRequest
{
    public Guid UserId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public int Quantity { get; set; }
}