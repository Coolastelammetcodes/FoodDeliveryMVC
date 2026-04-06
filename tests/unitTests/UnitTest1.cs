using Moq;
using domain.interfaces;
using domain.entities;
using domain.dto;

namespace unitTests;

public class UnitTest1
{
    [Fact]
    public async Task Should_Return_Correct_TotalPrice()
    {
        var mockOrderRepo = new Mock<IOrderRepository>();
        mockOrderRepo.Setup(or => or.AddNewOrderAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);

        var mockDishRepo = new Mock<IDishRepository>();
        var dish = new Dish{
            Id = 1,
            Price = 105,
            Restaurant = new Restaurant
            {
                Id = 3,
                DeliveryFee = 69,
                ServiceFee = 0.05m  
            }
        };
            mockDishRepo.Setup(dr => dr.ViewSpecificDishAsync(1)).ReturnsAsync(dish);

        var orderService = new OrderService(mockOrderRepo.Object, mockDishRepo.Object, null);

        var orderDto = new OrderRequestDTO
        {
            OrderItems = new List<OrderItemRequestDTO>
            {
                new OrderItemRequestDTO {DishID = 1, Quantity = 4}
            } 
        };

        var act = await orderService.AddNewOrderAsync(orderDto);

        Assert.Equal(510, act.TotalPrice);
    }
}
