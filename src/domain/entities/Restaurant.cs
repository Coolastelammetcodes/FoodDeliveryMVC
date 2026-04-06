namespace domain.entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; } 
    public TimeSpan Open { get; set; }
    public TimeSpan Closed { get; set; }
    public TimeSpan OrderDeadline { get; set; }
    public int DeliveryFee { get; set; }
    public decimal ServiceFee { get; set; } = 0.05m;
    
    public List<Dish>? Dishes{ get; set; }
}