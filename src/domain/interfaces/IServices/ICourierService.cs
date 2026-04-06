public interface ICourierService
{
    Task<CourierResponseDTO> AddNewCourierAsync(CourierRequestDTO reqDTO);
    Task<List<CourierResponseDTO>> ViewAllCouriersAsync();
}