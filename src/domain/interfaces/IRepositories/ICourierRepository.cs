public interface ICourierRepository
{
    Task AddNewCourierAsync(Courier courier);
    Task<List<Courier>> ViewAllCouriersAsync();
    Task<Courier?> GetCourierByPhoneNumAsync(string phoneNum);
}