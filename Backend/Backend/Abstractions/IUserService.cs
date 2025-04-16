using Backend.Models;

namespace Backend.Abstractions;

public interface IUserService
{
    Task<Guid> CreateUser(User user);

    Task<Guid> UpdateUser(Guid id, string password, string login, string email);
    Task<List<User?>> GetAllUsers();

    Task<Guid> DeleteUser(Guid id);
}