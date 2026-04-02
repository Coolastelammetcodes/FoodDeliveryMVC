using domain.interfaces;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepo;
    public CustomerService(ICustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
    }
    public async Task AddCustomerAsync(CustomerRequestDTO dto)
    {
        var customer = new Customer
        {
            Name = dto.Name,
            PhoneNum = dto.PhoneNum,
            Email = dto.Email
        };
        await _customerRepo.AddCustomerAsync(customer);
    }

}