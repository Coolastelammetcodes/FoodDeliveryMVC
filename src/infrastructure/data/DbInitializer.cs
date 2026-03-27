using domain.entities;

namespace infrastructure.data;
public class DbInitializer
{
    public async Task Initialize(FoodServiceContext db)
    {
        await SeedRestaurants(db);
    }
    public async Task SeedRestaurants(FoodServiceContext db)
    {
        var restaurant1 = new Restaurant 
        (   
            "Bob's Burgers",
            "Ocean Avenue",
            "Great burgers only at Bobs Burgers",
            new TimeSpan(09,00,0),
            new TimeSpan(21,00,0),
            new TimeSpan(20,45,0)
        );
         var restaurant2 = new Restaurant 
        (   
            "Krusty Burger",
            "Fast Food Boulevard",
            "Fun burgers",
            new TimeSpan(11,00,0),
            new TimeSpan(21,30,0),
            new TimeSpan(21,15,0)
        );
        await db.Restaurants.AddRangeAsync(restaurant1, restaurant2);
        await db.SaveChangesAsync();
    }
}