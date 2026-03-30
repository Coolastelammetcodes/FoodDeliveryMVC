using domain.dto;
using Microsoft.AspNetCore.Mvc;
using domain.interfaces;
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
    public async Task<IActionResult> AddRestaurant(RestaurantRequestDTO dto)
    {
        await _restaurantService.AddRestaurantAsync(dto);
        return Created();
    }
}