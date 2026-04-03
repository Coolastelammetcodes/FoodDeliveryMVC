using System.ComponentModel.DataAnnotations;
using domain.dto;

public class CustomerRequestDTO
{
    [Required(ErrorMessage = "Vänligen fyll i namn för att lägga beställning")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Vänligen fyll i telefon-nummer för att lägga beställning")]
    public string PhoneNum { get; set; } = string.Empty;
    [Required(ErrorMessage = "Vänligen fyll i email-address för att lägga beställning")]
    public string Email { get; set; } = string.Empty;
}