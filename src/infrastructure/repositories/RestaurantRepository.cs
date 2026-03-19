using domain.interfaces;
using domain.entities;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;
namespace infrastructure.repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly FoodServiceContext _dbContext;
    public RestaurantRepository(FoodServiceContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddNewRestaurantAsync(Restaurant restaurant)
    {
        _dbContext.Restaurants.Add(restaurant);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<List<Restaurant>> ViewAllRestaurantsAsync() => await _dbContext.Restaurants.ToListAsync();
    public async Task<Restaurant?> GetRestaurantByIdAsync(int id) => await _dbContext.Restaurants.FindAsync(id);
    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        _dbContext.Restaurants.Update(restaurant);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteRestaurantAsync(Restaurant restaurant)
    {
        _dbContext.Restaurants.Remove(restaurant);
        _dbContext.SaveChanges();
    } 
}