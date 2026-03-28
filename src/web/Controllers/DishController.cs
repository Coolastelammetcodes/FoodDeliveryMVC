using Microsoft.AspNetCore.Mvc;

public class DishController : Controller //TODO lägg till beskrivning till rätten 
{
    private readonly DishService _dishService;
    public DishController(DishService dishService)
    {
        _dishService = dishService;
    }
    // public async Task<IActionResult> Details(int id)
    // {
    //     // var dish = await _dishService.ViewSpecificDishAsync(id);
    //     // if(dish == null)
    //     // {
    //     //     return NotFound();
    //     // }
    //     // return View(dish);
    // }
}