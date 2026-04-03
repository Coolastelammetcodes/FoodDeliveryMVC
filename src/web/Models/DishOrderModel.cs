using domain.dto;

public class DishOrderModel
{
    public DishResponseDTO DishDto { get; set; } = new();
    public OrderResponseDTO OrderDto { get; set; } = new();
}