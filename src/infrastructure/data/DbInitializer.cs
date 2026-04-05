using domain.entities;
using domain.enums;
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
       await SeedOrdersAsync();
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
                    new TimeSpan(20,45,0),
                    79
                ),
                new Restaurant 
                (   
                    "Krusty Burger",
                    "Fast Food Boulevard",
                    "Fun burgers",
                    new TimeSpan(11,00,0),
                    new TimeSpan(21,30,0),
                    new TimeSpan(21,15,0),
                    65
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
    public async Task SeedOrdersAsync()
    {
        if(!await _db.Orders.AnyAsync())
        {
            var orders = new List<Order>
            {
                new Order
                {
                    Customer = new Customer { Name = "Alice", Email = "alice@mail.com", PhoneNum = "0701234567" },
                    Instructions = "Ingen lök tack",
                    DeliveryFee = 49,
                    ServiceFee = 0.05m,
                    TotalPrice = 200m,
                    OrderStatus = OrderStatusEnum.Received,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem(1, 2)
                    }
                },   
                new Order
                {
                    Customer = new Customer { Name = "Alfredo", Email = "Alfredo@mail.com", PhoneNum = "0702345678" },
                    Instructions = "Ingen lök tack",
                    DeliveryFee = 49,
                    ServiceFee = 0.05m,
                    TotalPrice = 200m,
                    OrderStatus = OrderStatusEnum.ReadyForPickup,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem(2, 4)
                    }
                }   
            };
            await _db.Orders.AddRangeAsync(orders);
            await _db.SaveChangesAsync();
        }
    }
}