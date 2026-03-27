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
}