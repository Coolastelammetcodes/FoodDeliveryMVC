namespace domain.entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; } 
    public int Price { get; set; }
    public int RestaurantID { get; set; }
    public Restaurant? Restaurant { get; set; }

    public Dish(string name, string description)
    {
        Name = name;
        Description = description;
    }
}