using domain.dto;

public interface IOrderService
{
    Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO orderDTO);
    Task<OrderResponseDTO?> ViewSpecificOrderWithDishesAsync(Guid Id);
}