namespace domain.entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan Open { get; set; }
    public TimeSpan Closed { get; set; }
    public TimeSpan OrderDeadline { get; set; }
    public int DeliveryFee { get; set; }
    public decimal ServiceFee { get; set; } = 0.05m;
    
    public List<Dish>? Dishes{ get; set; }
}