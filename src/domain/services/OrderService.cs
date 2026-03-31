using domain.entities;

public class OrderService 
{
    private readonly OrderItemService _orderItemService;
    public OrderService(OrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }
    
    private OrderItem MapToOrderItem(OrderItemRequestDTO oi) => new OrderItem (oi.DishID, oi.Quantity);

    private OrderResponseDTO MapToOrderResponseDTO(Order o) => new OrderResponseDTO(Id: o.Id, OrderItems: o.OrderItems.Select(oi => new OrderItemResponseDTO(oi.Id, oi.DishID, oi.Quantity)).ToList());

}