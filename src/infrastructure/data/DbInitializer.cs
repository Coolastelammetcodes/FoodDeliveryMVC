using domain.entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.data;
public class DbInitializer
{
    private readonly FoodServiceContext _db;
    public DbInitializer(FoodServiceContext db)
    {
        _db = db;
    }
    public async Task InitializeAsync()
    {
       await SeedRestaurantAsync();
       await SeedDishAsync();
    }
    public async Task SeedRestaurantAsync()
    {
        if(!await _db.Restaurants.AnyAsync())
        {
            var restaurants = new List<Restaurant>
            {
                new Restaurant(   
                    "Bob's Burgers",
                    "Ocean Avenue",
                    "Great burgers only at Bobs Burgers",
                    new TimeSpan(09,00,0),
                    new TimeSpan(21,00,0),
                    new TimeSpan(20,45,0)
                ),
                new Restaurant 
                (   
                    "Krusty Burger",
                    "Fast Food Boulevard",
                    "Fun burgers",
                    new TimeSpan(11,00,0),
                    new TimeSpan(21,30,0),
                    new TimeSpan(21,15,0)
                )  
            }; 
             
            await _db.Restaurants.AddRangeAsync(restaurants);
            await _db.SaveChangesAsync();
        }
    }
    public async Task SeedDishAsync()
    {
        if(!await _db.Dishes.AnyAsync())
        {
            var dishes = new List<Dish>
            {
                new Dish
                (
                    "Dubbel patty burger",
                    "Burger with double patty, ketchup and mayonnaise",
                    125,
                    1
                ),
                new Dish
                (
                    "Itchy and scratchy burger",
                    "Single mixed pattyburger with ketchup",
                    110,
                    2
                )
            };
            
            await _db.Dishes.AddRangeAsync(dishes);
            await _db.SaveChangesAsync();
        }
    }
}