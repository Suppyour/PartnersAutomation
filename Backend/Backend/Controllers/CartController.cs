using Backend.Abstractions;
using Backend.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCart([FromBody] CartRequest request)
    {
        var (cartItem, error) = CartItem.CreateCart(request.UserId, request.ProductId, request.Quantity);
        var result = await _cartService.CreateCart(cartItem);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<CartResponse>>> GetCart([FromQuery] Guid userId)
    {
        var carts = await _cartService.GetCart(userId);

        var responce = carts.Select(c => new CartResponse(c.CardId, c.UserId, c.ProductId, c.Quantity, c.AddedAt));

        return Ok(responce);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveFromCart([FromQuery] Guid userId, [FromQuery] Guid productId)
    {
        await _cartService.RemoveFromCart(userId, productId);
        return NoContent(); // 204 No Content
    }

    [HttpDelete("clear-all")]
    public async Task<IActionResult> ClearCart([FromQuery] Guid userId)
    {
        await _cartService.ClearCart(userId);
        return NoContent();
    }
}