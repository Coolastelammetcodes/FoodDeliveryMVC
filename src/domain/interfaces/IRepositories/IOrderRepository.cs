using domain.entities;

namespace domain.interfaces;
public interface IOrderRepository
{
    Task AddNewOrderAsync(Order order);
    Task<Order?> ViewSpecificOrderWithDishesAsync(Guid Id);
}