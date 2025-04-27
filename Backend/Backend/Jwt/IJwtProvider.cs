namespace Backend.Jwt;

public interface IJwtProvider
{
    string GenerateToken(Models.User user);
}