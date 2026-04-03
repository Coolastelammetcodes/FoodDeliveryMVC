using domain.dto;

public interface IOrderItemService
{
    Task<OrderItemDishResponseDTO> ViewSpecificOrderItemAsync(int id);
}