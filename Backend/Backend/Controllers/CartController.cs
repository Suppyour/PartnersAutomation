using Backend.Abstractions;
using Backend.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для работы с корзиной покупок. Реализует создание, получение, удаление элементов корзины и очистку корзины.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    /// <summary>
    /// Конструктор для инициализации контроллера.
    /// </summary>
    /// <param name="cartService">Сервис для работы с корзинами.</param>
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    /// <summary>
    /// Создание нового элемента в корзине.
    /// </summary>
    /// <param name="request">Данные для добавления в корзину (идентификатор пользователя, продукта и количество).</param>
    /// <returns>Идентификатор созданного элемента корзины.</returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCart([FromBody] CartRequest request)
    {
        var (cartItem, error) = CartItem.CreateCart(request.UserId, request.ProductId, request.Quantity);
        var result = await _cartService.CreateCart(cartItem);
        return Ok(result);
    }

    /// <summary>
    /// Получение всех товаров в корзине пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список товаров в корзине пользователя.</returns>
    [HttpGet]
    public async Task<ActionResult<List<CartResponse>>> GetCart([FromQuery] Guid userId)
    {
        var carts = await _cartService.GetCart(userId);

        var response = carts.Select(c => new CartResponse(c.CardId, c.UserId, c.ProductId, c.Quantity, c.AddedAt));

        return Ok(response);
    }

    /// <summary>
    /// Удаление товара из корзины пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="productId">Идентификатор продукта, который нужно удалить.</param>
    /// <returns>Статус ответа (204 No Content, если товар успешно удален).</returns>
    [HttpDelete]
    public async Task<IActionResult> RemoveFromCart([FromQuery] Guid userId, [FromQuery] Guid productId)
    {
        await _cartService.RemoveFromCart(userId, productId);
        return NoContent(); // 204 No Content
    }

    /// <summary>
    /// Очистка всей корзины пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя, чью корзину нужно очистить.</param>
    /// <returns>Статус ответа (204 No Content, если корзина успешно очищена).</returns>
    [HttpDelete("clear-all")]
    public async Task<IActionResult> ClearCart([FromQuery] Guid userId)
    {
        await _cartService.ClearCart(userId);
        return NoContent();
    }
}
