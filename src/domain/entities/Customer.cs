using domain.entities;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public List<Order?> Orders { get; set; } = new();
}