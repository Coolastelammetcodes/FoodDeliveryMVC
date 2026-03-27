using Microsoft.AspNetCore.Mvc;

public class RestaurantController : Controller
{
    private readonly IRestaurantService _restaurantService;
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    public async Task<IActionResult> Index()
    {
        var restaurants = await _restaurantService.ViewAllRestaurantsAsync();
        return View(restaurants);
    }
}