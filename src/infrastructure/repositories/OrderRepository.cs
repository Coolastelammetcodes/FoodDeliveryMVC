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
    public async Task AddNewOrderAsync(Order order)
    {
        await _db.Orders.AddAsync(order);
        await _db.SaveChangesAsync();
    }
    public async Task<Order?> ViewSpecificOrderAsync(Guid Id) => await _db.Orders.FindAsync(Id);
}