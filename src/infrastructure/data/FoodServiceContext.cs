using Microsoft.EntityFrameworkCore;
using domain.entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace infrastructure.data;

public class FoodServiceContext : IdentityDbContext<IdentityUser>
{
    public FoodServiceContext(DbContextOptions<FoodServiceContext> options) : base(options) {}
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}