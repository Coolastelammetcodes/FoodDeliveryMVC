using System.Security.Cryptography.X509Certificates;

public class CourierService : ICourierService
{
    private readonly ICourierRepository _courierRepo;
    public CourierService(ICourierRepository courierRepo)
    {
        _courierRepo = courierRepo;
    }

    public async Task AddNewCourierAsync(CourierRequestDTO reqDTO)
    {
        var newCourier = new Courier
        {
            FName = reqDTO.FName,
            LName = reqDTO.LName,
            PhoneNum = reqDTO.PhoneNum
        };

        await _courierRepo.AddNewCourierAsync(newCourier);
    }
}