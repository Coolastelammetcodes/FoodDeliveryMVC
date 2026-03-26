using domain.entities;

public interface IRestaurantService
{
    Task<List<Restaurant>> ViewAllRestaurantsAsync();
}