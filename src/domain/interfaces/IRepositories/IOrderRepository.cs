using domain.entities;

namespace domain.interfaces;
public interface IOrderRepository
{
    Task AddNewOrder(Order order);
}