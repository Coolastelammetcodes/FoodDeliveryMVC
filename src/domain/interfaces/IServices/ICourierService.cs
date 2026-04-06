public interface ICourierService
{
    Task<CourierResponseDTO> AddNewCourierAsync(CourierRequestDTO reqDTO);
    Task<CourierResponseDTO> GetCourierByIdAsync(int id);
    Task<List<CourierResponseDTO>> ViewAllCouriersAsync();
}