using domain.dto;
using domain.enums;

public interface IOrderService
{
    Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO orderDTO);
    Task<OrderResponseDTO?> ViewSpecificOrderWithDishesAsync(Guid Id);
    Task<OrderResponseDTO> UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus);
}