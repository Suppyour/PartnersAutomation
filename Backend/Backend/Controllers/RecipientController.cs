using Backend.Abstractions.Recipient;
using Backend.Contracts.Recipient;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// Контроллер для управления получателями.
/// </summary>
[ApiController]
[Route("api/recipients")]
public class RecipientController : ControllerBase
{
    private readonly IRecipientService _recipientService;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="RecipientController"/>.
    /// </summary>
    /// <param name="recipientService">Сервис для работы с получателями.</param>
    public RecipientController(IRecipientService recipientService)
    {
        _recipientService = recipientService;
    }

    /// <summary>
    /// Получает получателя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <returns>Ответ с объектом получателя или статус 404, если не найден.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RecipientResponce>> GetById(Guid id)
    {
        var recipient = await _recipientService.GetByIdAsync(id);
        if (recipient == null)
            return NotFound();

        return Ok(recipient);
    }

    /// <summary>
    /// Получает список всех получателей, принадлежащих пользователю.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Ответ со списком получателей.</returns>
    [HttpGet("user/{userId:guid}")]
    public async Task<ActionResult<List<RecipientResponce>>> GetAllByUser(Guid userId)
    {
        var recipients = await _recipientService.GetAllByUserAsync(userId);
        return Ok(recipients);
    }

    /// <summary>
    /// Создает нового получателя для указанного пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="request">Запрос с данными получателя.</param>
    /// <returns>Идентификатор созданного получателя.</returns>
    [HttpPost("user/{userId:guid}")]
    public async Task<ActionResult<Guid>> Create(Guid userId, [FromBody] RecipientRequest request)
    {
        var id = await _recipientService.CreateAsync(userId, request);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    /// <summary>
    /// Обновляет информацию о получателе.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <param name="request">Запрос с обновленными данными получателя.</param>
    /// <returns>Ответ без содержимого (204 No Content).</returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RecipientRequest request)
    {
        await _recipientService.UpdateAsync(id, request);
        return NoContent();
    }

    /// <summary>
    /// Удаляет получателя.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <returns>Ответ без содержимого (204 No Content).</returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _recipientService.DeleteAsync(id);
        return NoContent();
    }
}
