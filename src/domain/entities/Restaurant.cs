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
    
    public List<Dish>? Dishes{ get; set; }

    public Restaurant(string name, string address, string description ,TimeSpan open, TimeSpan closed, TimeSpan orderDeadline)
    {
        Name = name;
        Address = address;
        Description = description;
        Open = open;
        Closed = closed;
        OrderDeadline = orderDeadline;
    }
}