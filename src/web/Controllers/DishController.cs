using Microsoft.AspNetCore.Mvc;
using web.Models;

public class DishController : Controller 
{
    private readonly IDishService _dishService;
    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }
    public async Task<IActionResult> Details(int id)
    {
        var dish = await _dishService.ViewSpecificDishAsync(id);
        if(dish == null)
        {
            return NotFound();
        }
        return View(dish);
    }
}