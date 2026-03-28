using domain.entities;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class DishRepository : IDishRepository
{
    private readonly FoodServiceContext _dbContext;
    public DishRepository(FoodServiceContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Dish>> ViewAllDishesAsync() => await _dbContext.Dishes.ToListAsync(); 
    public async Task<Dish?> ViewSpecificDishAsync(int id) => await _dbContext.Dishes.FindAsync(id);
    public async Task AddNewDishAsync(Dish dish)
    {}

}