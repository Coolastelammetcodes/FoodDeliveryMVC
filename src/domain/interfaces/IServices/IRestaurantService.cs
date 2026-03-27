using domain.entities;

public interface IRestaurantService
{
    Task<List<ViewRestaurantDTO>> ViewAllRestaurantsAsync();
}