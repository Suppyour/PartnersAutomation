using Backend.Abstractions.Recipient;
using Backend.Entities;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

/// <summary>
/// Репозиторий для управления получателями.
/// </summary>
/// <param name="context">Контекст базы данных.</param>
public class RecipientRepository(MyDbContext context) : IRecipientRepository
{
    /// <summary>
    /// Получает всех получателей, принадлежащих указанному пользователю.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>Список получателей.</returns>
    public async Task<List<Recipient?>> GetAllByUserIdAsync(Guid userId)
    {
        var entities = await context.Recipients
            .Where(r => r.UserId == userId)
            .AsNoTracking()
            .ToListAsync();

        var recipients = entities.Select(e =>
        {
            var recipient = Recipient.Create(
                e.FirstName,
                e.LastName,
                e.Address,
                e.PhoneNumber
            );

            if (recipient is null)
                return null;

            recipient.Id = e.Id;
            recipient.UserId = e.UserId;
            recipient.CreatedAt = e.CreatedAt;
            recipient.UpdatedAt = e.UpdateAt;

            return recipient;
        }).Where(r => r != null)
          .ToList()!;

        return recipients;
    }

    /// <summary>
    /// Получает получателя по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <returns>Получатель, если найден, иначе null.</returns>
    public async Task<Recipient?> GetByIdAsync(Guid id)
    {
        var e = await context.Recipients
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);

        if (e == null)
            return null;

        var recipient = Recipient.Create(
            e.FirstName,
            e.LastName,
            e.Address,
            e.PhoneNumber
        );

        if (recipient == null)
            return null;

        recipient.Id = e.Id;
        recipient.UserId = e.UserId;
        recipient.CreatedAt = e.CreatedAt;
        recipient.UpdatedAt = e.UpdateAt;

        return recipient;
    }

    /// <summary>
    /// Создает нового получателя в базе данных.
    /// </summary>
    /// <param name="recipient">Объект получателя.</param>
    /// <returns>Идентификатор созданного получателя.</returns>
    /// <exception cref="ArgumentNullException">Вызывается, если передан null.</exception>
    public async Task<Guid> CreateAsyncRecipient(Recipient recipient)
    {
        if (recipient == null)
            throw new ArgumentNullException(nameof(recipient));

        var entity = new RecipientEntity
        {
            Id = recipient.Id,
            FirstName = recipient.FirstName,
            LastName = recipient.LastName,
            Address = recipient.Address,
            PhoneNumber = recipient.PhoneNumber,
            UserId = recipient.UserId,
            CreatedAt = recipient.CreatedAt,
            UpdateAt = recipient.UpdatedAt
        };

        await context.Recipients.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity.Id;
    }

    /// <summary>
    /// Обновляет данные получателя по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <param name="firstName">Имя получателя.</param>
    /// <param name="lastName">Фамилия получателя.</param>
    /// <param name="address">Адрес получателя.</param>
    /// <param name="phoneNumber">Телефонный номер получателя (может быть null).</param>
    /// <returns>Идентификатор обновленного получателя.</returns>
    public async Task<Guid> UpdateAsync(Guid id, string firstName, string lastName, string address, string? phoneNumber)
    {
        await context.Recipients
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(set => set
                .SetProperty(r => r.FirstName, _ => firstName)
                .SetProperty(r => r.LastName, _ => lastName)
                .SetProperty(r => r.Address, _ => address)
                .SetProperty(r => r.PhoneNumber, _ => phoneNumber)
                .SetProperty(r => r.UpdateAt, _ => DateTime.UtcNow)
            );

        return id;
    }

    /// <summary>
    /// Удаляет получателя из базы данных.
    /// </summary>
    /// <param name="id">Идентификатор получателя.</param>
    /// <returns>Идентификатор удаленного получателя.</returns>
    public async Task<Guid> DeleteAsync(Guid id)
    {
        await context.Recipients
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}
