using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts;

public record RegisterUserRequest(
    [Required] string Login,
    [Required] string Password,
    [Required] string Email
    );