using domain.entities;

public interface IOrderItemService
{
    Task AddOrderItemAsync(OrderItemRequestDTO dto);
}