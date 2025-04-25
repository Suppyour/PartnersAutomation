using Backend.Abstractions;
using Backend.Entites;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class CartRepository : ICartRepository
{
    private readonly MyDbContext _context;

    public CartRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<CartEntity> CreateCart(CartEntity cartItem)
    {
        await _context.Cart.AddAsync(cartItem);
        await _context.SaveChangesAsync();
        return cartItem;
    }

    public async Task<List<CartEntity>> GetCart(Guid userId)
    {
        return await _context.Cart
            .Where(c => c.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Guid> RemoveFromCart(Guid userId, Guid productId)
    {
        await _context.Cart
            .Where(c => c.UserId == userId && c.ProductId == productId)
            .ExecuteDeleteAsync();
        return productId;
    }

    public async Task<Guid> ClearCart(Guid userId)
    {
        await _context.Cart
            .Where(c => c.UserId == userId)
            .ExecuteDeleteAsync();
        return userId;
    }
}