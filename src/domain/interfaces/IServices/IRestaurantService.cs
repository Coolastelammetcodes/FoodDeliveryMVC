using domain.entities;
using domain.dto.response;

public interface IRestaurantService
{
    Task<List<ViewRestaurantDTO>> ViewAllRestaurantsAsync();
    Task<ViewRestaurantDTO> ViewSpecificRestaurant(int id);
}