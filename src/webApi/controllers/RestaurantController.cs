using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantService _restaurantService;

    public RestaurantController(RestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpPost]
    [Route("AddRestaurant")]
    public async Task<IActionResult> AddRestaurant(AddRestaurantDTO dto)
    {
        await _restaurantService.AddRestaurantAsync(dto);
        return Ok();
    }
}