using Backend.Abstractions;
using Backend.Contracts;
using Backend.DTOrders;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ICartService _cartService;

    public OrdersController(IOrderService orderService, ICartService cartService)
    {
        _orderService = orderService;
        _cartService = cartService;
    }

    /// <summary>
    /// Создание заказа из выбранных элементов корзины.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
    {
        
        var allCartItems = await _cartService.GetCart(request.UserId);
        var selectedItems = allCartItems
            .Where(c => request.CartItemIds.Contains(c.CardId))
            .ToList();

        if (!selectedItems.Any())
            return BadRequest("Нет выбранных элементов корзины.");
        var orderId = await _orderService.CreateOrder(request.UserId, selectedItems);

        return Ok(new { OrderId = orderId });
    }
}