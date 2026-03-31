using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(OrderRequestDTO reqDto)
    {
        var order = await _orderService.AddNewOrderAsync(reqDto);
        return RedirectToAction("Confirmation", new { id = order.Id});
    }
    [HttpGet]
    public async Task<IActionResult> Confirmation(Guid id)
    {
        
    }
}