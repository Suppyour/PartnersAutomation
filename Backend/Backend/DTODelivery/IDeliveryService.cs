namespace Backend.DTODelivery;

public interface IDeliveryService
{
    Task<DeliveryResponse> CreateForOrderAsync(Guid orderId, DeliveryRequest request);
    Task UpdateStatusAsync(Guid deliveryId, string status);
}
