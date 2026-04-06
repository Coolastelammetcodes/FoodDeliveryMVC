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
                new Restaurant
                {   
                    Name = "Bob's Burgers",
                    Address = "Ocean Avenue",
                    Description = "Great burgers only at Bobs Burgers",
                    Open = new TimeSpan(09,00,0),
                    Closed = new TimeSpan(21,00,0),
                    OrderDeadline = new TimeSpan(20,45,0),
                    DeliveryFee = 79
                },
                new Restaurant 
                {  
                    Name = "Krusty Burger",
                    Address = "Fast Food Boulevard",
                    Description = "Fun burgers",
                    Open = new TimeSpan(11,00,0),
                    Closed = new TimeSpan(21,30,0),
                    OrderDeadline = new TimeSpan(21,15,0),
                    DeliveryFee = 65
                }  
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
                {
                    Name = "Dubbel patty burger",
                    Description = "Burger with double patty, ketchup and mayonnaise",
                    Price = 125,
                    RestaurantID = 1
                },
                new Dish
                {
                    Name = "Itchy and scratchy burger",
                    Description = "Single mixed pattyburger with ketchup",
                    Price = 110,
                    RestaurantID = 2
                }
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
                    Customer = new Customer { FName = "Lisa", LName = "Simpson", Email = "Lisa.s@mail.com", PhoneNum = "0701234567" },
                    Instructions = "Ingen lök tack",
                    DeliveryFee = 49,
                    ServiceFee = 0.05m,
                    TotalPrice = 200m,
                    OrderStatus = OrderStatusEnum.Received,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem{DishID = 1, Quantity = 2}
                    }
                },   
                new Order
                {
                    Customer = new Customer { FName = "Alfredo", LName = "Panini", Email = "Alfredo@mail.com", PhoneNum = "0702345678" },
                    Instructions = "Ingen lök tack",
                    DeliveryFee = 49,
                    ServiceFee = 0.05m,
                    TotalPrice = 200m,
                    OrderStatus = OrderStatusEnum.ReadyForPickup,
                    OrderItems = new List<OrderItem>
                    {
                        new OrderItem{DishID = 2, Quantity = 4}
                    }
                }   
            };
            await _db.Orders.AddRangeAsync(orders);
            await _db.SaveChangesAsync();
        }
    }
}