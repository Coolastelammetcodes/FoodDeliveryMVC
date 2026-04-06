using System.Security.Cryptography.X509Certificates;

public class CourierService : ICourierService
{
    private readonly ICourierRepository _courierRepo;
    public CourierService(ICourierRepository courierRepo)
    {
        _courierRepo = courierRepo;
    }

    public async Task<CourierResponseDTO> AddNewCourierAsync(CourierRequestDTO reqDTO)
    {
        var courierPhone = await _courierRepo.GetCourierByPhoneNumAsync(reqDTO.PhoneNum);
        if (courierPhone != null)
        {
            throw new Exception("Ett annat bud har redan detta telefonnummer");    
        }

        var newCourier = new Courier
        {
            FName = reqDTO.FName,
            LName = reqDTO.LName,
            PhoneNum = reqDTO.PhoneNum
        };
        await _courierRepo.AddNewCourierAsync(newCourier);
        return MapToCourierResponseDTO(newCourier);
    }
    public async Task<CourierResponseDTO> GetCourierByIdAsync(int id)
    {
        var courier = await _courierRepo.GetCourierByIdAsync(id);
        if(courier == null)
        {
            throw new Exception("Kunde inte hitta bud");
        } 
        return MapToCourierResponseDTO(courier);
    }
    public async Task<List<CourierResponseDTO>> ViewAllCouriersAsync()
    {
        var couriers = await _courierRepo.ViewAllCouriersAsync();
        return couriers.Select(MapToCourierResponseDTO).ToList();
    }
    private CourierResponseDTO MapToCourierResponseDTO(Courier courier) => new CourierResponseDTO{
                                    Id = courier.Id,
                                    FName = courier.FName,
                                    LName = courier.LName,
                                    PhoneNum = courier.PhoneNum,
                                    IsAvailable = courier.IsAvailable
                                }; 
}