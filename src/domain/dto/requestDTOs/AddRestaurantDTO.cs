using System.ComponentModel.DataAnnotations;
namespace domain.dto.request;
public class AddRestaurantDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required] 
    public string Address { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty; 
    [Required]
    public TimeSpan Open { get; set; }
    [Required]
    public TimeSpan Closed { get; set; }
    [Required]
    public TimeSpan OrderDeadline { get; set;}
    
}