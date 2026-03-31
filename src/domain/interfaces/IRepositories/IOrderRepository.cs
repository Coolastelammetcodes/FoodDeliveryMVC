using domain.entities;

namespace domain.interfaces;
public interface IOrderRepository
{
    Task AddNewOrderAsync(Order order);
    Task<Order?> ViewSpecificOrderAsync(Guid Id);
}