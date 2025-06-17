namespace Backend.Abstractions.Recipient;

public interface IRecipientRepository
{
    Task <Models.Recipient?> GetByIdAsync(Guid id);
    Task<List<Models.Recipient?>> GetAllByUserIdAsync(Guid userId);
    Task<Guid> CreateAsyncRecipient(Models.Recipient recipient);
    Task<Guid> UpdateAsync(Guid id, string firstName, string lastName, string address, string? phoneNumber);
    Task<Guid> DeleteAsync(Guid id);
}

