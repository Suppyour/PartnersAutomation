using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Backend.DTODelivery;
using Backend.DTOrders;
using Backend.Entities;
using Backend.Models;

namespace Backend.Repositories
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<RecipientEntity> Recipients { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<OrderItem> OrderItems { get; set; }
        
        public DbSet<DeliveryEntity> Deliveries { get; set; }
        
        public async Task RecreateDatabase()
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();
        }
    }
}