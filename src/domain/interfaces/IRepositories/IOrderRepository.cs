using domain.entities;
using domain.enums;

namespace domain.interfaces;
public interface IOrderRepository
{
    Task AddNewOrderAsync(Order order);
    Task<Order?> ViewSpecificOrderWithDishesAsync(Guid Id);
    Task UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus);
}