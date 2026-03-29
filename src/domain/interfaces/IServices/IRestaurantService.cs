using domain.dto;

public interface IRestaurantService
{
    Task<List<RestaurantResponseDTO>> ViewAllRestaurantsAsync();
    Task<RestaurantResponseDTO> ViewSpecificRestaurant(int id);
    Task AddRestaurantAsync(RestaurantRequestDTO dto);
}