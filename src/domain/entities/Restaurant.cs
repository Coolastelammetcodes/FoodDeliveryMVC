namespace domain.entities;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNum { get; set; }
    public TimeSpan Open { get; set; }
    public TimeSpan Closed { get; set; }
    public bool IsOpen { get; set; }
    public string Description { get; set; } 
    public List<Dish>? Dishes{ get; set; }

    public Restaurant(string name, string address, string phoneNum, string description)
    {
        Name = name;
        Address = address;
        PhoneNum = phoneNum;
        Description = description;
    }
}