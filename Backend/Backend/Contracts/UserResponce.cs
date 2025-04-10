namespace Backend.Contracts;

public record UserResponce(
    Guid UserId,
    string Password,
    string Email,
    string Login);
    
public record UserRequest(
    string Password,
    string Email,
    string Login);