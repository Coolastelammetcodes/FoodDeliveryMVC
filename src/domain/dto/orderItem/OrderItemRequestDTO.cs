using System.ComponentModel.DataAnnotations;

public class OrderItemRequestDTO
{
    [Required]
    public int DishID { get; set; }
    [Required]
    public int Quantity { get; set; }
}