namespace domain.entities;
public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid(); 
    public List<OrderItem> OrderItems { get; set; } = new();
}