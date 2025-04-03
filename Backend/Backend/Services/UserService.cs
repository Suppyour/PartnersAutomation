using Backend.Abstractions;
using Backend.Models;

namespace Backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
}