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
        {
            Id = orderItem.Id,
            Quantity = orderItem.Quantity,
            DishID = orderItem.DishID,
            DishName = orderItem.Dish?.Name ?? "",
            DishPrice = orderItem.Dish?.Price ?? 0
        };

        return oiDto;
    } 
}