using Backend.Entites;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.REPO
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }
        // Пошла реализация CRUD r(ead) - get  
        public async Task<List<User?>> GetUsers()
        {
            var userEntity = await _context.Users
                .AsNoTracking() // Не изменяем данные => юзаем 
                .ToListAsync();
            // мы получили Entity, а не список User
            var users = userEntity
                .Select(x => User.Create(x.Id, x.Login, x.Email, x.Password).User)
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
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setProperty => setProperty
                    .SetProperty(b => b.Password, b => password)
                    .SetProperty(b => b.Login, b => login)
                    .SetProperty(b => b.Email, b => email));
            return id;
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            await _context.Users
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}