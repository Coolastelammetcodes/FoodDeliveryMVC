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
    public async Task<IActionResult> Index(int id)
    {
        var restaurant = await _restaurantService.ViewSpecificRestaurant(id);
        if(restaurant == null)
        {
            return NotFound();
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
}