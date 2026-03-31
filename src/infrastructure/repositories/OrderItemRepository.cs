using domain.entities;
using domain.interfaces;
using infrastructure.data;

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
}