using System.Runtime.Versioning;
using infrastructure.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route ("api/[controller]")] //TODO Fixa resten av REST API
[Authorize]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantService _restaurantService;
    private readonly FoodServiceContext _dbContext;
    public RestaurantController(RestaurantService restaurantService, FoodServiceContext dbContext)
    {
        _restaurantService = restaurantService;
        _dbContext = dbContext;
    }

    [HttpPost]
    [Route("AddRestaurant")]
    public async Task<IActionResult> AddRestaurant(AddRestaurantDTO dto)
    {
        await _restaurantService.AddRestaurantAsync(dto);
        return Ok();
    }
}