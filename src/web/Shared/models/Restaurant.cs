namespace web.Shared.models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public string OpenHours { get; set; } = string.Empty;
    public bool IsOpen { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Dish>? Dishes{ get; set; }
}