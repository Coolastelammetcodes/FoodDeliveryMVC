using System.ComponentModel.DataAnnotations;
namespace domain.dto;
public class OrderRequestDTO
{
    [Required]
    public List<OrderItemRequestDTO> OrderItems{ get; set; } = new();
}