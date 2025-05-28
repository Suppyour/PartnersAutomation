using Backend.Abstractions;
using Backend.Abstractions.Password;
using Backend.Jwt;
using Backend.Models;


namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IJwtProvider _jwtProvider;

    public UserService(IPasswordHasher passwordHasher, IUserRepository userRepository, IJwtProvider jwtProvider)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _jwtProvider = jwtProvider;
    }
    public async Task<List<User?>> GetAllUsers()
    {
        return await _userRepository.GetUser();
    }

    public async Task<Guid> CreateUser(User user)
    {
        return await _userRepository.CreateUser(user);
    }

    public async Task<Guid> UpdateUser(Guid id, string password, string login, string email)
    {
        return await _userRepository.UpdateUser(id, password, login, email);
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        return await _userRepository.DeleteUser(id);
    }
    
    // --------------------------------------------------------------------------------------- //

    public async Task<Guid> Register(string login, string email, string password)
    {
        var hashedPassword = _passwordHasher.GenerateHash(password);

        var (user, error) = User.Create(Guid.NewGuid(), login, email, hashedPassword);
        
        await _userRepository.CreateUser(user);
        
        return user.Id;
    }

    public async Task<object> Login(string login, string password, string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
    
        if (user == null)
        {
            throw new Exception("Пользователь не найден");
        }

        var result = _passwordHasher.VerifyHash(password, user.Password);
        if (!result)
        {
            throw new Exception("Неверный пароль");
        }

        var token = _jwtProvider.GenerateToken(user);

        return new { token, userId = user.Id };
    }
}