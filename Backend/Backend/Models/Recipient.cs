namespace Backend.Models;
public class Recipient
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Recipient() { }

    private Recipient(string firstName, string lastName, string address, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        CreatedAt = DateTime.UtcNow;
    }

    public static Recipient? Create(string firstName, string lastName, string address, string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return null;
        if (string.IsNullOrWhiteSpace(lastName))
            return null;

        if (string.IsNullOrWhiteSpace(address))
            return null;

        return new Recipient(firstName, lastName, address, phoneNumber);
    }

    public void Update(string firstName, string lastName, string address, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PhoneNumber = phoneNumber;
        UpdatedAt = DateTime.UtcNow;
    }
}
