namespace domain.interfaces;
public interface ICustomerRepository
{
    Task AddCustomer(Customer customer);
}