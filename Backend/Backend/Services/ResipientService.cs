using Backend.Abstractions.Recipient;
using Backend.Contracts.Recipient;
using Backend.Models;

namespace Backend.Services;

public class RecipientService : IRecipientService
{
    private readonly IRecipientRepository _repository;

    public RecipientService(IRecipientRepository repository)
    {
        _repository = repository;
    }

    public async Task<RecipientResponce?> GetByIdAsync(Guid id)
    {
        var model = await _repository.GetByIdAsync(id);
        return model == null ? null : MapToResponse(model);
    }


    public async Task<List<RecipientResponce>> GetAllByUserAsync(Guid userId)
    {
        var models = await _repository.GetAllByUserIdAsync(userId);
        return models
            .Where(r => r != null)
            .Select(r => MapToResponse(r!))
            .ToList();
    }

    public async Task<Guid> CreateAsync(Guid userId, RecipientRequest request)
    {
        var model = new Recipient
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            UserId = userId
        };

        return await _repository.CreateAsyncRecipient(model);
    }

    public async Task UpdateAsync(Guid id, RecipientRequest request)
    {
        await _repository.UpdateAsync(
            id,
            request.FirstName,
            request.LastName,
            request.Address,
            request.PhoneNumber
        );
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    private static RecipientResponce MapToResponse(Recipient model) => new()
    {
        Id = model.Id,
        FirstName = model.FirstName,
        LastName = model.LastName,
        Address = model.Address,
        PhoneNumber = model.PhoneNumber
    };
}