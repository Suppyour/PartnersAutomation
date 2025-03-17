using Backend;
using Microsoft.EntityFrameworkCore;

namespace UsersBD.Repositories
{
    public class UserRepository
    {

        private readonly UsersDbContext _context;
        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            var userEntity = await _context.Users
                .AsNoTracking() // Не изменяем данные => юзаем 
                .ToListAsync();
            var users = userEntity
                .Select(x => User.Create(x.Id, x.Login, x.Email, x.Password).User)
                .ToList();
            return users;
        }
    }
}
