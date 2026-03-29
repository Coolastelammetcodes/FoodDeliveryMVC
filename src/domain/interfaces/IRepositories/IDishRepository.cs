using domain.entities;
namespace domain.interfaces;
public interface IDishRepository
{
    Task<List<Dish>> ViewAllDishesAsync();
    Task<List<Dish>> GetDishesForRestaurantAsync(int restaurantID);
    Task<Dish?> ViewSpecificDishAsync(int id);
    Task AddNewDishAsync(Dish dish);
}