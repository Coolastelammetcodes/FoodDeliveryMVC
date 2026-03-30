namespace domain.entities;
public class Order
{
    public int Id { get; set; }
    public List<OrderItem?> OrderItems { get; set; } = new();
}