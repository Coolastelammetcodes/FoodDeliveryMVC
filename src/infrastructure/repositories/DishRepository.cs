using domain.entities;
using domain.interfaces;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class DishRepository : IDishRepository
{
    private readonly FoodServiceContext _dbContext;
    public DishRepository(FoodServiceContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Dish>> GetDishesForRestaurantAsync(int restaurantID) => await _dbContext.Dishes.Where(d => d.RestaurantID == restaurantID).ToListAsync();
    public async Task<List<Dish>> ViewAllDishesAsync() => await _dbContext.Dishes.ToListAsync(); 
    public async Task<Dish?> ViewSpecificDishAsync(int id) => await _dbContext.Dishes.FindAsync(id);
    public async Task AddNewDishAsync(Dish dish)
    {}

}