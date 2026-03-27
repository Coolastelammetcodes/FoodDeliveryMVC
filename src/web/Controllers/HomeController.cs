using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web.Models;

namespace web.Controllers;

public class HomeController : Controller
{
    private readonly IRestaurantService _restaurantService;
    public HomeController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    public async Task<IActionResult> Index()
    {
        var restaurants = await _restaurantService.ViewAllRestaurantsAsync();
        if(restaurants == null || !restaurants.Any())
        {
            return NotFound();
        }
        return View(restaurants);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
