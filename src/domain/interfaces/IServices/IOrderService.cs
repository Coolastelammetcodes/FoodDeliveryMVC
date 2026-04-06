using domain.dto;
using domain.enums;

public interface IOrderService
{
    Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO orderDTO);
    Task<List<OrderResponseDTO>> ViewOrdersByStatus(OrderStatusEnum orderStatus);
    Task<List<OrderResponseDTO>> ViewAllOrdersAsync();
    Task<OrderResponseDTO?> ViewSpecificOrderWithDishesAsync(Guid Id);
    Task<OrderResponseDTO> UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus);
    Task<OrderResponseDTO> AssignCourierToOrder(Guid orderId, int courierID);
}