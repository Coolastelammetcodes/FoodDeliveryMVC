public interface ICustomerService
{
    Task AddCustomerAsync(CustomerRequestDTO customerDto);
}