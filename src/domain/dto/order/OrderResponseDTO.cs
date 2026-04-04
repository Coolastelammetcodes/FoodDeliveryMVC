namespace domain.dto;
public record class OrderResponseDTO()
{
    public Guid Id { get; init;}
    public List<OrderItemDishResponseDTO> OrderItems { get; init; } = new();
    public CustomerResponseDTO Customer { get; init; } = new();
    public string Instructions { get; init; } = string.Empty;
    public decimal TotalPrice { get; init; }
}