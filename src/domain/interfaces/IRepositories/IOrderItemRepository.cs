using domain.entities;
namespace domain.interfaces;
public interface IOrderItemRepository
{
    Task AddOrderItemAsync(OrderItem orderItem);
    Task<OrderItem?> ViewSpecificOrderItem(int id);
}