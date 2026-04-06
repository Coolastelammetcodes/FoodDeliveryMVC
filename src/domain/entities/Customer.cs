using domain.entities;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Order?> Orders { get; set; } = new(); // används för att hämta ut alla ordrar som tillhör en specifik kund
}