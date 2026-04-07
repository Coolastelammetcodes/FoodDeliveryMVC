namespace domain.entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public int RestaurantID { get; set; }
    public Restaurant? Restaurant { get; set; } 
}