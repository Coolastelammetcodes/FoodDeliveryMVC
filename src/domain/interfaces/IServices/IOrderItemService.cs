using domain.dto;

public interface IOrderItemService
{
    Task AddOrderItemAsync(OrderItemRequestDTO dto);
}