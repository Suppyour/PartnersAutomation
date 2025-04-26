namespace Backend.Contracts;

public record UserRequest(
    string Password,
    string Email,
    string Login);