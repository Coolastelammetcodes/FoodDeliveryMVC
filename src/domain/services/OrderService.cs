using domain.entities;
using domain.interfaces;
using domain.dto;

public class OrderService : IOrderService
{   
    private readonly IOrderRepository _orderRepo;
    public OrderService(IOrderRepository orderRepo)
    {
        _orderRepo = orderRepo;
    }
    public async Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO reqDto)
    {
        var order = new Order
        {
            Customer = MapToCustomer(reqDto.Customer),
            OrderItems = reqDto.OrderItems.Select(MapToOrderItem).ToList(),
            Instructions = reqDto.Instructions
        };
        await _orderRepo.AddNewOrderAsync(order);
        return MapToOrderResponseDTO(order);
    }
    public async Task<OrderResponseDTO?> ViewSpecificOrderWithDishesAsync(Guid Id)
    {
        var order = await _orderRepo.ViewSpecificOrderWithDishesAsync(Id);
        if(order == null)
        {
            return null;
        }
        return MapToOrderResponseDTO(order);
    }
    private Customer MapToCustomer(CustomerRequestDTO c) => new Customer {Name = c.Name, PhoneNum = c.PhoneNum, Email = c.Email};
    private CustomerResponseDTO MapToCustomerResponse(Customer c) => new CustomerResponseDTO{Id = c.Id, Name = c.Name, Email = c.Email, PhoneNum = c.PhoneNum}; 
    private OrderItem MapToOrderItem(OrderItemRequestDTO oi) => new OrderItem (oi.DishID, oi.Quantity);
    private OrderResponseDTO MapToOrderResponseDTO(Order o)
    {
        return new OrderResponseDTO{ Id = o.Id, Customer = o.Customer != null ? MapToCustomerResponse(o.Customer) : null, OrderItems = o.OrderItems.Select(oi => new OrderItemDishResponseDTO(oi.Id, oi.DishID, oi.Quantity, oi.Dish?.Name ?? "", oi.Dish?.Price ?? 0)).ToList()};
    }    
}