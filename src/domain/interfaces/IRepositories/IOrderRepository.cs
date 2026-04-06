using domain.entities;
using domain.enums;

namespace domain.interfaces;
public interface IOrderRepository
{
    Task AddNewOrderAsync(Order order);
    Task<List<Order>> ViewOrdersByStatusAsync(OrderStatusEnum orderStatus);
    Task<List<Order>> ViewAllOrdersAsync();
    Task<Order?> ViewSpecificOrderWithDishesAsync(Guid Id);
    Task UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus);
    Task AssignCourierToOrder(Guid orderId, int courierID);
}