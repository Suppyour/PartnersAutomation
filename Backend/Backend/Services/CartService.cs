using Backend.Abstractions;
using Backend.Abstractions.Cart;
using Backend.Entities;
using Backend.Models;

namespace Backend.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<List<CartItem>> GetCart(Guid userId)
    {
        var entities = await _cartRepository.GetCart(userId);

        return entities.Select(e => new CartItem
        {
            CardId = e.Id,
            UserId = e.UserId,
            ProductId = e.ProductId,
            Quantity = e.Quantity,
            AddedAt = e.AddedAt
        }).ToList();
    }

    public async Task<Guid> CreateCart(CartItem cart)
    {
        var entity = new CartEntity
        {
            Id = cart.CardId,
            UserId = cart.UserId,
            ProductId = cart.ProductId,
            Quantity = cart.Quantity,
            AddedAt = cart.AddedAt
        };

        await _cartRepository.CreateCart(entity);
        return entity.Id;
    }

    public async Task<Guid> RemoveFromCart(Guid userId, Guid productId)
    {
        return await _cartRepository.RemoveFromCart(userId, productId);
    }

    public async Task<Guid> ClearCart(Guid userId)
    {
        return await _cartRepository.ClearCart(userId);
    }

    public async Task<Guid> UpdateCart(Guid id, int quantity)
    {
        throw new Exception("позже");
    }
}