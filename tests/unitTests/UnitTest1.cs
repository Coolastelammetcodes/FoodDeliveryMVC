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
        var mockDishRepo = new Mock<IDishRepository>();

        var dish = new Dish{
            Id = 1,
            Price = 105,
            Restaurant = new Restaurant
            {
            Id = 3,
            DeliveryFee = 69,
            ServiceFee = 0.1m  
            }
        };
    }
}
