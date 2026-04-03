using domain.entities;
using domain.interfaces;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : IOrderRepository
{
    private readonly FoodServiceContext _db;
    public OrderRepository(FoodServiceContext db)
    {
        _db = db;
    }
    public async Task AddNewOrderAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
    }
    public async Task<Order?> ViewSpecificOrderWithDishesAsync(Guid Id) => await _db.Orders.Include(o => o.Customer).Include(o => o.OrderItems).ThenInclude(oi => oi.Dish).FirstOrDefaultAsync(o => o.Id == Id);
}