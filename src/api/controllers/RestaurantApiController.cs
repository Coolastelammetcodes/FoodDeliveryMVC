using domain.dto;
using Microsoft.AspNetCore.Mvc;
using domain.interfaces;
using Swashbuckle.AspNetCore.Filters;
[ApiController]
[Route("api/[controller]")]
public class RestaurantApiController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    public RestaurantApiController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    [HttpPost]
    [SwaggerRequestExample(typeof(RestaurantRequestDTO), typeof(RestaurantRequestPlaceholder))]
    public async Task<IActionResult> AddRestaurant(RestaurantRequestDTO dto)
    {
        await _restaurantService.AddRestaurantAsync(dto);
        return Created();
    }
   // TODO kanske ta bort DishApiController bara använda RestaurantController för att visa eller ta bort maträtter. 
}