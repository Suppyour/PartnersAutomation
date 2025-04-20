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
    public async Task<ActionResult<Guid>> AddToCart([FromBody] CartRequest request)
    {
        var result = await _cartService.AddToCart(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<CartResponse>>> GetCart([FromQuery] Guid userId)
    {
        var carts = await _cartService.GetCart(userId);

        var responce = carts.Select(c => new CartResponse(c.Id, c.UserId, c.ProductId, c.Quantity, c.AddedAt));
        
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