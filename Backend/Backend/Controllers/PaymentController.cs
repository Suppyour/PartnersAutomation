using Backend.Abstractions.Payment;
using Backend.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для работы с платежами через YooKassa.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Создает новый платеж и возвращает ссылку на оплату.
    /// </summary>
    /// <param name="request">Данные платежа: сумма и идентификатор заказа.</param>
    /// <returns>Ссылка на YooKassa для проведения оплаты.</returns>
    /// <response code="200">Платеж успешно создан.</response>
    /// <response code="400">Ошибка в переданных данных запроса.</response>
    [HttpPost("Create")]
    [ProducesResponseType(typeof(PaymentResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentResponse>> CreatePayment([FromBody] PaymentRequest request)
    {
        var response = await _paymentService.CreatePaymentAsync(request);
        return Ok(response);
    }

    /// <summary>
    /// Обрабатывает входящий webhook от YooKassa.
    /// </summary>
    /// <param name="body">Тело запроса с данными о платеже (event, object.id, object.status).</param>
    /// <returns>HTTP 200 OK, если обработка прошла успешно.</returns>
    /// <remarks>
    /// YooKassa вызывает этот метод после изменения статуса платежа.
    /// </remarks>
    [HttpPost("callback")]
    public async Task<IActionResult> Callback([FromBody] dynamic body)
    {
        string eventType = body.@event;
        string paymentId = body.@object.id;
        string status = body.@object.status;

        await _paymentService.HandleCallbackAsync(eventType, paymentId, status);
        return Ok();
    }
}
