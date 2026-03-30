using domain.dto;
namespace web.Models;
public class RestaurantDishModel
{
    public RestaurantResponseDTO? Restaurant { get; set; }
    public List<DishResponseDTO>? Dishes { get; set; } 
}