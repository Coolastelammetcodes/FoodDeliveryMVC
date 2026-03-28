using domain.dto.restaurant;
using domain.dto.dish;
namespace web.Models;
public class RestaurantDishModel
{
    public RestaurantResponseDTO? Restaurant { get; set; }
    public List<DishResponseDTO>? Dishes { get; set; } 
}