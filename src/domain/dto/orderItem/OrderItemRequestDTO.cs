using System.ComponentModel.DataAnnotations;
namespace domain.dto;
public class OrderItemRequestDTO
{
    [Required]
    public int DishID { get; set; }
    [Required]
    [Range(1,25)]
    public int Quantity { get; set; }
}