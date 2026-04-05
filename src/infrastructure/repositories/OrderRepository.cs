using System.Reflection.Metadata.Ecma335;
using domain.dto;
using domain.entities;
using domain.enums;
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
    public async Task<List<Order>> ViewOrdersByStatusAsync(OrderStatusEnum orderStatus) => await _db.Orders
                                    .Include(o => o.Customer)
                                    .Include(o => o.OrderItems)
                                    .ThenInclude(oi => oi.Dish)
                                    .ThenInclude(d => d.Restaurant)
                                    .Where(o => o.OrderStatus == orderStatus)
                                    .ToListAsync();
    public async Task<List<Order>> ViewAllOrdersAsync() => await _db.Orders
                                    .Include(o => o.Customer)
                                    .Include(o => o.OrderItems)
                                    .ThenInclude(oi => oi.Dish)
                                    .ThenInclude(d => d.Restaurant)
                                    .ToListAsync();
    public async Task<Order?> ViewSpecificOrderWithDishesAsync(Guid Id) => await _db.Orders.Include(o => o.Customer)
                                    .Include(o => o.OrderItems)
                                    .ThenInclude(oi => oi.Dish)
                                    .ThenInclude(d => d.Restaurant)
                                    .FirstOrDefaultAsync(o => o.Id == Id);
    public async Task UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus)
    {
        var order = await _db.Orders.FindAsync(id);
        if(order == null) return;

        order.OrderStatus = orderStatus;
        await _db.SaveChangesAsync();
    }
}