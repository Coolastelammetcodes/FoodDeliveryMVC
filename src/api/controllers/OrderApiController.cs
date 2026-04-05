using domain.enums;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class OrderApiController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderApiController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPatch]
    public async Task<IActionResult> UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus)
    {
        var order = await _orderService.UpdateOrderStatusAsync(id, orderStatus);
        
        if(order == null) return NotFound();
        
        return Ok(order);
    }
}