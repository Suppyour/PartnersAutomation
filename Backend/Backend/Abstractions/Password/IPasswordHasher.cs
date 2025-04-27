namespace Backend.Abstractions.Password;

public interface IPasswordHasher
{
    string GenerateHash(string password);
    
    bool VerifyHash(string password, string hash);
}