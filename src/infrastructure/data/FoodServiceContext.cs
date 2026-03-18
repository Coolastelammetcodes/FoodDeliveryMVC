using Microsoft.EntityFrameworkCore;
using domain.entities;
namespace infrastructure.data;

public class FoodServiceContext : DbContext
{
    public FoodServiceContext(DbContextOptions<FoodServiceContext> options) : base(options) {}
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}