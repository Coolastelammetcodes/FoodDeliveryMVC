using domain.entities;

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}