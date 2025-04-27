using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts;

public record LoginUserRequest(string Email, string Password)
{
    public string Login { get; set; }
}
