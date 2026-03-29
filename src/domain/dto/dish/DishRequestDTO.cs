using System.ComponentModel.DataAnnotations;
namespace domain.dto;
public class DishRequestDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public int Price { get; set; }
    [Required]
    public int RestaurantID { get; set; }
}