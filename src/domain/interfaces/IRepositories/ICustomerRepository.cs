namespace domain.interfaces;
public interface ICustomerRepository
{
    Task AddCustomerAsync(Customer customer);
}