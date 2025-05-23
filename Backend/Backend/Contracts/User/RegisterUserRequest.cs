using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts;

public record RegisterUserRequest(
    [Required(ErrorMessage = "Login is required")]
    [MinLength(3, ErrorMessage = "Login must be at least 3 characters")]
    string Login,
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    string Email,
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    string Password
);