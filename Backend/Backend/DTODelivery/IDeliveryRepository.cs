namespace Backend.DTODelivery;

public interface IDeliveryRepository
{
    Task<DeliveryEntity> CreateAsync(DeliveryEntity delivery);
    Task<DeliveryEntity?> GetByOrderIdAsync(Guid orderId);
    Task UpdateStatusAsync(Guid deliveryId, string newStatus);
}
