namespace domain.dto;
public record RestaurantResponseDTO(int Id, string Name, string Address, string Description, TimeSpan Open, TimeSpan Closed, TimeSpan OrderDeadline);