using domain.entities;

public interface IOrderService
{
    Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO orderDTO);
}