using Backend.Contracts.Recipient;

namespace Backend.Abstractions.Recipient;

public interface IRecipientService
{
    Task<RecipientResponce?> GetByIdAsync(Guid id);
    Task<List<RecipientResponce?>> GetAllByUserAsync(Guid userId);
    Task<Guid> CreateAsync(Guid userId, RecipientRequest request);
    Task UpdateAsync(Guid id, RecipientRequest request);
    Task DeleteAsync(Guid id);
}
