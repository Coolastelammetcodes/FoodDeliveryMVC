using domain.entities;
using domain.interfaces;
using infrastructure.data;

public class OrderRepository : IOrderRepository
{
    private readonly FoodServiceContext _db;
    public OrderRepository(FoodServiceContext db)
    {
        _db = db;
    }
    public async Task AddNewOrder(Order order)
    {
        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
    }
}