using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Backend.Entities;

namespace Backend.Repositories
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        
        public DbSet<SizeEntity> Sizes { get; set; }
        
        public DbSet<ProductSizeEntity> ProductSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSizeEntity>(entity =>
            {
                entity.HasKey(ps => new { ps.ProductId, SizeName = ps.SizeId });
            
                entity.HasOne(ps => ps.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(ps => ps.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            
                entity.HasOne(ps => ps.Size)
                    .WithMany(s => s.ProductSizes)
                    .HasForeignKey(ps => ps.SizeId)
                    .OnDelete(DeleteBehavior.Restrict);
            }); 
        }

        public async Task RecreateDatabase()
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }
}