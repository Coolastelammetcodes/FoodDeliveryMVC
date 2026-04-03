using Microsoft.AspNetCore.Mvc;
using domain.dto;
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IDishService _dishService;
    
    public OrderController(IOrderService orderService, IDishService dishService)
    {
        _orderService = orderService;
        _dishService = dishService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(DishOrderModel dishOrderModel, OrderRequestDTO oReqDTO)
    {
        if(!ModelState.IsValid)
        {
            var dishId = oReqDTO.OrderItems[0].DishID;
            
            var dish = await _dishService.ViewSpecificDishAsync(dishId);
            dishOrderModel.DishDto = dish ?? new DishResponseDTO();
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