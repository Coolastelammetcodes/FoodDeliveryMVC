using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
}