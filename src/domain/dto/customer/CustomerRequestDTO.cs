using System.ComponentModel.DataAnnotations;
using domain.dto;

public class CustomerRequestDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string PhoneNum { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}