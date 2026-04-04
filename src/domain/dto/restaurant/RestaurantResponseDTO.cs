namespace domain.dto;
public record class RestaurantResponseDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public TimeSpan Open { get; init; }
    public TimeSpan Closed { get; init; }
    public TimeSpan OrderDeadline { get; init; }
    public int DeliveryFee { get; init; }
    public decimal ServiceFee { get; init; }
}