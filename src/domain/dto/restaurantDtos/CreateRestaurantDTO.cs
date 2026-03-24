using System.ComponentModel.DataAnnotations;

public class CreateRestaurantDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required] 
    public string Address { get; set; } = string.Empty;
    [Required] 
    public string PhoneNum { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public TimeSpan Open { get; set; }
    public TimeSpan Closed { get; set; }
    
}