using Backend.DTODelivery;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders/{orderId}/delivery")]
public class DeliveryController : ControllerBase
{
    private readonly IDeliveryService _service;

    public DeliveryController(IDeliveryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Guid orderId, [FromBody] DeliveryRequest request)
    {
        var response = await _service.CreateForOrderAsync(orderId, request);
        return Ok(response);
    }

    [HttpPatch("{deliveryId}/status")]
    public async Task<IActionResult> UpdateStatus(Guid deliveryId, [FromBody] string status)
    {
        await _service.UpdateStatusAsync(deliveryId, status);
        return NoContent();
    }
}
