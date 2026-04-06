public interface ICourierRepository
{
    Task AddNewCourierAsync(Courier courier);
    Task<List<Courier>> ViewAllCouriersAsync();
    Task<Courier?> GetCourierByIdAsync(int id);
    Task<Courier?> GetCourierByPhoneNumAsync(string phoneNum);
}