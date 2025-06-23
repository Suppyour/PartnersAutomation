namespace Backend.DTODelivery;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _repo;

    public DeliveryService(IDeliveryRepository repo)
    {
        _repo = repo;
    }

    public async Task<DeliveryResponse> CreateForOrderAsync(Guid orderId, DeliveryRequest request)
    {
        decimal price = CalculateDeliveryPrice(request.DeliveryMethod);
        var entity = new DeliveryEntity
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            DeliveryMethod = request.DeliveryMethod,
            Address = request.Address,
            Price = price,
            Status = "pending",
            CreatedAt = DateTime.UtcNow
        };

        await _repo.CreateAsync(entity);

        return new DeliveryResponse
        {
            Id = entity.Id,
            DeliveryMethod = entity.DeliveryMethod,
            Address = entity.Address,
            Price = entity.Price,
            Status = entity.Status
        };
    }

    public Task UpdateStatusAsync(Guid deliveryId, string status)
        => _repo.UpdateStatusAsync(deliveryId, status);

    private decimal CalculateDeliveryPrice(string method)
    {
        return method switch
        {
            "courier" => 300,
            "pickup" => 0,
            "post" => 150,
            _ => 0
        };
    }
}
