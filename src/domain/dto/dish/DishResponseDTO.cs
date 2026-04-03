namespace domain.dto;
public record class DishResponseDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public int Price { get; init; } 
    public int RestaurantID { get; init; }
    public RestaurantResponseDTO Restaurant { get; init; } = new();
}