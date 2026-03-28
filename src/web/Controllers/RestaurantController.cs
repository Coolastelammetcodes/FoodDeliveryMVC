using Microsoft.AspNetCore.Mvc;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly IDishService _dishService;
    public RestaurantController(IRestaurantService restaurantService, IDishService dishService)
    {
        _restaurantService = restaurantService;
        _dishService = dishService;
    }
    public async Task<IActionResult> Index()
    {
        var dishes = await _dishService.ViewAllDishesAsync();
        if(dishes == null || !dishes.Any())
        {
            return NotFound();
        }
        return View(dishes);
    }
    public async Task<IActionResult> Details(int id)
    {
        var restaurant = await _restaurantService.ViewSpecificRestaurant(id);
        if(restaurant == null)
        {
            return NotFound();
        }
        return View(restaurant);
    }
}