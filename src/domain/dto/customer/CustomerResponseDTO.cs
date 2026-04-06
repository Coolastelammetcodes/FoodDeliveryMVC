using domain.dto;
using domain.entities;

public record class CustomerResponseDTO
{
    public Guid Id { get; init; }
    public string FName { get; init; } = string.Empty;
    public string LName { get; set; } = string.Empty; // TODO ändra i service klasserna och i seeddata
    public string PhoneNum { get; init; } = string.Empty;
    public string Email{ get; init; } = string.Empty;
}