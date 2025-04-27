namespace Backend.Jwt;

public class JwtOpitons
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpireHours { get; set; }
}