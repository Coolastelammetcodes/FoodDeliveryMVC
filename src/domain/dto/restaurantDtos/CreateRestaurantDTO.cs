public class CreateRestaurantDTO
{
    public required string Name { get; set; } 
    public required string Address { get; set; } 
    public required string PhoneNum { get; set; } 
    public TimeSpan Open { get; set; }
    public TimeSpan Closed { get; set; }
    public required string Description { get; set; } 
}