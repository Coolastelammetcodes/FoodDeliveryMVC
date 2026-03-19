using domain.entities;
namespace domain.interfaces;

public interface IRestaurantRepository
{
    Task AddNewRestaurantAsync(Restaurant restaurant);
    Task<List<Restaurant>> ViewAllRestaurantsAsync();
    Task<Restaurant?> GetRestaurantByIdAsync(int Id);
    Task UpdateRestaurantAsync(Restaurant restaurant);
    Task DeleteRestaurantAsync(Restaurant restaurant); 
}