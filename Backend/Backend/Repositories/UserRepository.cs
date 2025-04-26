using Backend.Abstractions;
using Backend.Entites;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<User?>> GetUser()
        {
            var userEntity = await _context.Users
                .AsNoTracking() // Не изменяем данные => юзаем 
                .ToListAsync();
            // мы получили Entity, а не список User
            var users = userEntity
                .Select(u => User.Create(u.Id, u.Login, u.Email, u.Password).User)
                .ToList();
            return users;
        }  

        public async Task<Guid> CreateUser(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            
            return userEntity.Id;
        }

        public async Task<Guid> UpdateUser(Guid id, string password, string login, string email)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(setProperty => setProperty
                    .SetProperty(u => u.Password, u => password)
                    .SetProperty(u => u.Login, u => login)
                    .SetProperty(u => u.Email, u => email));
            return id;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}