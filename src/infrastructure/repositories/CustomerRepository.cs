using System.Runtime.CompilerServices;
using domain.interfaces;
using infrastructure.data;
namespace infrastructure.repositories;
public class CustomerRepository : ICustomerRepository
{
    private readonly FoodServiceContext _db;
    public CustomerRepository(FoodServiceContext db) => _db = db;
    
        
    
    public async Task AddCustomerAsync(Customer customer)
    {
        await _db.Customers.AddAsync(customer);
        await _db.SaveChangesAsync();   
    }
}