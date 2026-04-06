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
    [HttpGet("orderStatus/{orderStatus}")]
    public async Task<IActionResult> ViewOrdersByStatus(OrderStatusEnum orderStatus)
    {
        var orders = await _orderService.ViewOrdersByStatus(orderStatus);

        if(orders == null) return NotFound();

        return Ok(orders);
    }
    [HttpGet("AllOrders")]
    public async Task<IActionResult> ViewAllOrdersAsync()
    {
        var orders = await _orderService.ViewAllOrdersAsync();
        
        if(orders == null) return NotFound();
        
        return Ok(orders);
    }
    [HttpPatch("UpdateOrderStatus/order{id}/{orderStatus}")]
    public async Task<IActionResult> UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus)
    {
        var order = await _orderService.UpdateOrderStatusAsync(id, orderStatus);
        
        if(order == null) return NotFound();
        
        return Ok(order);
    }
    [HttpPatch("AssignCourierToOrder/Order{orderId}/Courier{courierID}")]
    public async Task<IActionResult> AssignCourierToOrder(Guid orderId, int courierID)
    {
        try
        {
            var order = await _orderService.AssignCourierToOrder(orderId, courierID);

            if(order == null) return NotFound();

            return Ok(order);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}