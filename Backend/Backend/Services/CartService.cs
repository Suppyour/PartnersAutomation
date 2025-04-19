using Backend.Abstractions;
using Backend.Contracts;
using Backend.Entites;

namespace Backend.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartResponse> AddToCart(CartRequest request)
    {
        var entity = new CartEntity
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            AddedAt = DateTime.UtcNow
        };

        var result = await _cartRepository.AddToCart(entity);

        return new CartResponse
        {
            Id = result.Id,
            UserId = result.UserId,
            ProductId = result.ProductId,
            Quantity = result.Quantity,
            AddedAt = result.AddedAt
        };
    }

    public async Task<List<CartResponse>> GetCart(Guid userId)
    {
        var items = await _cartRepository.GetCart(userId);

        return items.Select(item => new CartResponse
        {
            Id = item.Id,
            UserId = item.UserId,
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            AddedAt = item.AddedAt
        }).ToList();
    }

    public async Task<Guid> RemoveFromCart(Guid userId, Guid productId)
    {
        return await _cartRepository.RemoveFromCart(userId, productId);
    }

    public async Task<Guid> ClearCart(Guid userId)
    {
        return await _cartRepository.ClearCart(userId);
    }
}