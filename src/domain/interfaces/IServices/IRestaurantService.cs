using domain.entities;
using domain.dto.restaurant;

public interface IRestaurantService
{
    Task<List<RestaurantResponseDTO>> ViewAllRestaurantsAsync();
    Task<RestaurantResponseDTO> ViewSpecificRestaurant(int id);
    Task AddRestaurantAsync(RestaurantRequestDTO dto);
}