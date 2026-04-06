using infrastructure.data;
using Microsoft.EntityFrameworkCore;

public class CourierRepository : ICourierRepository
{
    private readonly FoodServiceContext _db;
    public CourierRepository(FoodServiceContext db)
    {
        _db = db;
    }
        
    public async Task AddNewCourierAsync(Courier courier)
    {
        await _db.Couriers.AddAsync(courier);
        await _db.SaveChangesAsync();
    }
    public async Task<List<Courier>> ViewAllCouriersAsync()
    {
        var couriers = await _db.Couriers.ToListAsync();
        return couriers;
    }
    public async Task<Courier?> GetCourierByPhoneNumAsync(string phoneNum) => await _db.Couriers.FirstOrDefaultAsync(courier => courier.PhoneNum == phoneNum);
}