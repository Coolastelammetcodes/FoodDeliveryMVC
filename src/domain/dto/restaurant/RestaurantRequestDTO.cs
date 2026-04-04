using System.ComponentModel.DataAnnotations;
namespace domain.dto;
public class RestaurantRequestDTO
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
    [Required]
    public int DeliveryFee { get; set; }
    public decimal ServiceFee { get; set; } = 0.05m;
}