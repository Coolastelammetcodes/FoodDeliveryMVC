using System.ComponentModel.DataAnnotations;
namespace domain.dto;
public class OrderRequestDTO
{
    [Required]
    public List<OrderItemRequestDTO> OrderItems{ get; set; } = new();
    public string Instructions { get; set; } = string.Empty;
    [Required]
    public int CustomerID { get; set; }
    public CustomerResponseDTO Customer { get; set; } = new();
}