using domain.entities;
using domain.interfaces;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly FoodServiceContext _db;
    public OrderItemRepository(FoodServiceContext db)
    {
        _db = db;
    }
    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        await _db.OrderItems.AddAsync(orderItem);
        await _db.SaveChangesAsync();
    }
    public async Task<OrderItem?> ViewSpecificOrderItemWithDishAsync(int id) => await _db.OrderItems.Include(oi => oi.Dish).FirstOrDefaultAsync(oi => oi.Id == id);
}