using Backend.Entites;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }

        public async Task RecreateDatabase()
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }
}