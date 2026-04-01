using domain.dto;

public interface IOrderItemService
{
    Task AddOrderItemAsync(OrderItemRequestDTO dto);
    Task<OrderItemDishResponseDTO> ViewSpecificOrderItemAsync(int id);
}