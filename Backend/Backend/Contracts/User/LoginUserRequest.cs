using System.ComponentModel.DataAnnotations;

namespace Backend.Contracts;

public record LoginUserRequest(
    [Required(ErrorMessage = "Login is required")]
    [EmailAddress(ErrorMessage = "Invalid login format")]
    string Login,
    
    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    string Password,
    
    [Required(ErrorMessage = "Email is required")]
    [MinLength(6, ErrorMessage = "Email must be at least 6 characters")]
    string Email
);