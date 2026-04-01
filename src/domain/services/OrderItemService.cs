using domain.entities;
using domain.interfaces;
using domain.dto;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepo;
    public OrderItemService(IOrderItemRepository orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }
    public async Task AddOrderItemAsync(OrderItemRequestDTO dto)
    {
        if(dto.Quantity < 1)
        {
            throw new Exception("Det måste vara minst 1 antal");
        }
        var orderItem = new OrderItem
        (
            dto.DishID,
            dto.Quantity
        );

        await _orderItemRepo.AddOrderItemAsync(orderItem);
    }
    public async Task<OrderItemDishResponseDTO> ViewSpecificOrderItemAsync(int id)
    {
        var orderItem = await _orderItemRepo.ViewSpecificOrderItemWithDishAsync(id);
        if(orderItem == null)
        {
            return null;
        }
        var oiDto = new OrderItemDishResponseDTO
        (
            orderItem.Id,
            orderItem.Quantity,
            orderItem.DishID,
            orderItem.Dish?.Name ?? "",
            orderItem.Dish?.Price ?? 0
        );

        return oiDto;
    } 
}