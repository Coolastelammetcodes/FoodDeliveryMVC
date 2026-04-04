using Microsoft.AspNetCore.Mvc;
using web.Models;

public class DishController : Controller 
{
    private readonly IDishService _dishService;
    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var dish = await _dishService.ViewSpecificDishAsync(id);
        if(dish == null)
        {
            return NotFound();
        }
        var doModel = new DishOrderModel
        {
            DishDto = dish,
            OrderDto = new domain.dto.OrderResponseDTO()   
        };
        return View(doModel);
    }
}