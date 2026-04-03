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
    private OrderItem MapToOrderItem(OrderItemRequestDTO oi) => new OrderItem (oi.DishID, oi.Quantity);
}