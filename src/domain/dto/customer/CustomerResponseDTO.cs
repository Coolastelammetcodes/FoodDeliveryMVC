using domain.dto;
using domain.entities;

public record class CustomerResponseDTO
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string PhoneNum { get; init; } = string.Empty;
    public string Email{ get; init; } = string.Empty;
    public List<OrderResponseDTO?> Orders { get; init; } = new();

}