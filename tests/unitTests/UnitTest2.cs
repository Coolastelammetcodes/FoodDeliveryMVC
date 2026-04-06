using Moq;
using domain.interfaces;
using domain.entities;
using domain.dto;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace unitTests;

public class UnitTest2
{
    [Fact]
    public async Task Should_Throw_Exception_If_Courier_PhoneNum_Already_Exists()
    {
        var courier = new Courier {Id = 4, FName = "Snoop", LName = "Dogg", PhoneNum = "0712345678"};

        var mockCourierRepo = new Mock<ICourierRepository>();
        mockCourierRepo.Setup(cr => cr.GetCourierByPhoneNumAsync("0712345678")).ReturnsAsync(courier);

        var courierService = new CourierService(mockCourierRepo.Object);

        var courierDto = new CourierRequestDTO
        {
            FName = courier.FName,
            LName = courier.LName,
            PhoneNum = courier.PhoneNum
        };

        Func<Task> act = async () => await courierService.AddNewCourierAsync(courierDto);

        var exception = await Assert.ThrowsAsync<Exception>(act);
        Assert.Equal("Ett annat bud har redan detta telefonnummer", exception.Message);
    }   
}
