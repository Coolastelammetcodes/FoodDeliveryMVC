using domain.entities;
using domain.interfaces;
using domain.dto;
using domain.enums;

public class OrderService : IOrderService
{   
    private readonly IOrderRepository _orderRepo;
    private readonly IDishRepository _dishRepo;
    public OrderService(IOrderRepository orderRepo, IDishRepository dishRepo)
    {
        _orderRepo = orderRepo;
        _dishRepo = dishRepo;
    }
    public async Task<OrderResponseDTO> AddNewOrderAsync(OrderRequestDTO reqDto)
    {
        if(reqDto.Customer == null 
        || string.IsNullOrWhiteSpace(reqDto.Customer.Name)
        || string.IsNullOrWhiteSpace(reqDto.Customer.Email)
        || string.IsNullOrWhiteSpace(reqDto.Customer.PhoneNum))
        {
            throw new Exception("Fyll i dina uppgifter för att gå vidare");
        }

        var result = await CalculateTotalPriceAsync(reqDto);

        var order = new Order
        {
            Customer = MapToCustomer(reqDto.Customer),
            OrderItems = result.OrderItems,
            Instructions = reqDto.Instructions,
            DeliveryFee = result.DeliveryFee,
            ServiceFee = result.ServiceFee,
            TotalPrice = result.TotalPrice
        };
        await _orderRepo.AddNewOrderAsync(order);
        return MapToOrderResponseDTO(order);
    }
    public async Task<List<OrderResponseDTO>> ViewOrdersByStatus(OrderStatusEnum orderStatus)
    {
        var orders = await _orderRepo.ViewOrdersByStatusAsync(orderStatus);
        return orders.Select(MapToOrderResponseDTO).ToList();
    }
    public async Task<List<OrderResponseDTO>> ViewAllOrdersAsync()
    {
        var orders = await _orderRepo.ViewAllOrdersAsync();
        return orders.Select(MapToOrderResponseDTO).ToList();
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
    public async Task<OrderResponseDTO> UpdateOrderStatusAsync(Guid id, OrderStatusEnum orderStatus)
    {
        await _orderRepo.UpdateOrderStatusAsync(id, orderStatus);
        return await ViewSpecificOrderWithDishesAsync(id);
    }

    //Här under kommer det bara privata hjälp-metoder för att göra koden i huvud-metoderna mer läsbara.  

    private Customer MapToCustomer(CustomerRequestDTO c) => new Customer {Name = c.Name, PhoneNum = c.PhoneNum, Email = c.Email};
    private CustomerResponseDTO MapToCustomerResponse(Customer c) => new CustomerResponseDTO{Id = c.Id, Name = c.Name, Email = c.Email, PhoneNum = c.PhoneNum}; 
    private OrderItem MapToOrderItem(OrderItemRequestDTO oi) => new OrderItem (oi.DishID, oi.Quantity);
    private OrderResponseDTO MapToOrderResponseDTO(Order o)
    {
        return new OrderResponseDTO
        { 
            Id = o.Id, 
            Instructions = o.Instructions,
            DeliveryFee = o.DeliveryFee,
            ServiceFee = o.ServiceFee,
            TotalPrice = o.TotalPrice, 
            Customer = o.Customer != null ? MapToCustomerResponse(o.Customer) : new CustomerResponseDTO(),
            OrderStatus = o.OrderStatus,

            OrderItems = o.OrderItems.Select(oi => new OrderItemDishResponseDTO{
            Id = oi.Id, 
            DishID = oi.DishID, 
            Quantity = oi.Quantity, 
            DishName = oi.Dish?.Name ?? "", 
            DishPrice = oi.Dish?.Price ?? 0
            }).ToList()
        };
    }
    private async Task<OrderCalculationResultDTO> CalculateTotalPriceAsync(OrderRequestDTO reqDto)
    {
        var orderItems = reqDto.OrderItems.Select(MapToOrderItem).ToList();

        decimal itemsTotal = 0;

        foreach(var item in orderItems)
        {
            var dish = await _dishRepo.ViewSpecificDishAsync(item.DishID);
            item.Dish = dish;
            itemsTotal += dish.Price * item.Quantity;
        } 
        
        var restaurant = orderItems[0].Dish.Restaurant;
        decimal serviceFee = itemsTotal * restaurant.ServiceFee;
        decimal totalPrice = itemsTotal + restaurant.DeliveryFee + serviceFee;
        
        return new OrderCalculationResultDTO
        {
            OrderItems = orderItems,
            DeliveryFee = restaurant.DeliveryFee,
            ServiceFee = restaurant.ServiceFee,
            TotalPrice = totalPrice
        };
    }    
}