using Backend.Models;

namespace Backend.REPO;
// Нужна для внедрения с зависямостями
public interface IUserRepository
{
    Task<Guid> CreateUser(User user);
    Task<Guid> DeleteUser (Guid id);
    Task<List<User?>> GetUsers();
    Task<Guid> UpdateUser(Guid id, string password, string login, string email);

}