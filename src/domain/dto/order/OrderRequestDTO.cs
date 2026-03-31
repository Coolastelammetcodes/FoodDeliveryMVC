using System.ComponentModel.DataAnnotations;

public class OrderRequestDTO
{
    [Required]
    public List<OrderItemResponseDTO> OrderItems{ get; set; } = new();
}