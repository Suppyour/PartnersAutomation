using Backend.Abstractions;
using Backend.Contracts;
using Backend.DTOrders;
using Backend.Entities;
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
    /// Создаёт заказ из выбранных элементов корзины
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOrder([FromBody] OrderRequest request)
    {
        var cartItems = await _cartService.GetCart(request.UserId);

        var selectedItems = cartItems
            .Where(c => request.CartItemIds.Contains(c.CardId))
            .ToList();

        if (!selectedItems.Any())
            return BadRequest("Нет выбранных товаров для заказа.");

        var orderId = await _orderService.CreateOrder(request.UserId, selectedItems);

        return Ok(orderId);
    }

    /// <summary>
    /// Получает все заказы (админ-доступ)
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrders();

        return Ok(orders);
    }

    /// <summary>
    /// Получает все заказы конкретного пользователя
    /// </summary>
    [HttpGet("user/{userId:guid}")]
    public async Task<ActionResult<List<OrderResponse>>> GetUserOrders(Guid userId)
    {
        var orders = await _orderService.GetUserOrders(userId);

        return Ok(orders);
    }

    /// <summary>
    /// Получает один заказ по ID
    /// </summary>
    [HttpGet("{orderId:guid}")]
    public async Task<ActionResult<OrderResponse>> GetOrderById(Guid orderId)
    {
        var order = await _orderService.GetOrderById(orderId);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    /// <summary>
    /// Удаляет заказ по ID
    /// </summary>
    [HttpDelete("{orderId:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid orderId)
    {
        await _orderService.DeleteOrder(orderId);
        return NoContent();
    }
}
