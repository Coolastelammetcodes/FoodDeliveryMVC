using System.ComponentModel.DataAnnotations;
using domain.dto;

public class CustomerRequestDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "Förnamn måste vara minst 2 tecken")]
    [MaxLength(50, ErrorMessage = "Förnamn får innehålla högst 50 tecken")]
    public string FName { get; set; } = string.Empty;
    
    [Required]
    [MinLength(2, ErrorMessage = "Efternamn måste vara minst 2 tecken")]
    [MaxLength(50, ErrorMessage = "Efternamn får innehålla högst 50 tecken")]
    public string LName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Vänligen fyll i telefon-nummer för att lägga beställning")]
    [RegularExpression(@"^(\+46|0)7\d{8}$")]
    public string PhoneNum { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Vänligen fyll i email-address för att lägga beställning")]
    public string Email { get; set; } = string.Empty;
}