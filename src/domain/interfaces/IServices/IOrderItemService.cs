using domain.dto;

public interface IOrderItemService
{
    Task AddOrderItemAsync(OrderItemRequestDTO dto);
    Task<OrderItemResponseDTO> ViewSpecificOrderItemAsync(int id);
}