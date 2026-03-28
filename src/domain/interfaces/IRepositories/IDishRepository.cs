using domain.dto.restaurant;
using domain.entities;

public interface IDishRepository
{
    Task<List<Dish>> ViewAllDishesAsync();
    Task<Dish?> ViewSpecificDishAsync(int id);
    Task AddNewDishAsync(Dish dish);
}