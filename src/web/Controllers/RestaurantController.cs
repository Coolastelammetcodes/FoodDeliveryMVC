using Microsoft.AspNetCore.Mvc;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
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