using Microsoft.Identity.Client;

namespace Backend.Entities;

public class RecipientEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    
    public Guid UserId { get; set; }
    
    
}