using domain.entities;
using domain.interfaces;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class DishRepository : IDishRepository
{
    private readonly FoodServiceContext _db;
    public DishRepository(FoodServiceContext db)
    {
        _db = db;
    }
    public async Task<List<Dish>> GetDishesForRestaurantAsync(int restaurantID) => await _db.Dishes.Where(d => d.RestaurantID == restaurantID).Include(d => d.Restaurant).ToListAsync();
    public async Task<List<Dish>> ViewAllDishesAsync() => await _db.Dishes.ToListAsync(); 
    public async Task<Dish?> ViewSpecificDishAsync(int id) => await _db.Dishes.Include(d => d.Restaurant).FirstOrDefaultAsync(d => d.Id == id);
    public async Task AddNewDishAsync(Dish dish)
    {
        await _db.Dishes.AddAsync(dish);
        await _db.SaveChangesAsync();
    }

}