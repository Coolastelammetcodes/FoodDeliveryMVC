using Microsoft.AspNetCore.Mvc;
using web.Models;
public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    private readonly IDishService _dishService;
    public RestaurantController(IRestaurantService restaurantService, IDishService dishService)
    {
        _restaurantService = restaurantService;
        _dishService = dishService;
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var timeNow = new TimeSpan(05,59,00);
        var restaurant = await _restaurantService.ViewSpecificRestaurant(id);
        if(restaurant == null)
        {
            return NotFound();
        }
        
        if(timeNow >= restaurant.OrderDeadline && timeNow >= restaurant.Closed || timeNow < restaurant.Open)
        {
            return RedirectToAction("Closed", "Restaurant", new{id = restaurant.Id});
        }
        
        var dishes = await _dishService.GetDishesForRestaurantAsync(id);
        if(dishes == null || !dishes.Any())
        {
            return NotFound();
        }
        var viewModel = new RestaurantDishModel
        {
            Restaurant = restaurant,
            Dishes = dishes
        };
        return View(viewModel);
    }
    [HttpGet]
    public async Task<IActionResult> Closed(int id)
    {
        var restaurant = await _restaurantService.ViewSpecificRestaurant(id);
    
        var viewModel = new RestaurantDishModel
        {
            Restaurant = restaurant,
        };
        return View(viewModel);
    }
}