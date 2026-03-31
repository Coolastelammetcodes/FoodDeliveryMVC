using domain.entities;
using domain.interfaces;

public class OrderService : IOrderService
{   
    private readonly IOrderRepository _orderRepo;
    private readonly OrderItemService _orderItemService;
    public OrderService(IOrderRepository orderRepo, OrderItemService orderItemService)
    {
        _orderRepo = orderRepo;
        _orderItemService = orderItemService;
    }
    public async Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO reqDto)
    {
        var order = new Order
        {
            OrderItems = reqDto.OrderItems.Select(MapToOrderItem).ToList()
        };
        await _orderRepo.AddNewOrderAsync(order);
        return MapToOrderResponseDTO(order);
    }
    private OrderItem MapToOrderItem(OrderItemRequestDTO oi) => new OrderItem (oi.DishID, oi.Quantity);

    private OrderResponseDTO MapToOrderResponseDTO(Order o) => new OrderResponseDTO(Id: o.Id, OrderItems: o.OrderItems.Select(oi => new OrderItemResponseDTO(oi.Id, oi.DishID, oi.Quantity)).ToList());

}