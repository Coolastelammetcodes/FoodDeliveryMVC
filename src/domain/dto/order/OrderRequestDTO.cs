using System.ComponentModel.DataAnnotations;

public class OrderRequestDTO
{
    [Required]
    public List<OrderItemRequestDTO> OrderItems{ get; set; } = new();
}