using Microsoft.AspNetCore.Mvc;
using domain.dto;
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(DishOrderModel dishOrderModel, OrderRequestDTO oReqDTO)
    {
        if(!ModelState.IsValid)
        {
            return View("~/Views/Dish/Details.cshtml", dishOrderModel);
        }
        var order = await _orderService.AddNewOrderAsync(oReqDTO);
        return RedirectToAction("Confirmation", new { id = order.Id});
    }
    [HttpGet]
    public async Task<IActionResult> Confirmation(Guid Id)
    {
        var order = await _orderService.ViewSpecificOrderWithDishesAsync(Id);
        if(order == null)
        {
            return NotFound();
        }
        return View(order);
    }
}