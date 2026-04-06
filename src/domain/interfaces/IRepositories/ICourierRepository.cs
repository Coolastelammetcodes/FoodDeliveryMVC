public interface ICourierRepository
{
    Task AddNewCourier(Courier courier);
    Task<List<Courier>> ViewAllCouriersAsync();
    Task<Courier?> ViewSpecificCourier(int id);
}