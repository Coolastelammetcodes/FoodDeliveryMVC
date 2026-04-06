using System.ComponentModel.DataAnnotations;

public class CourierRequestDTO
{
    [Required]
    [MinLength(2, ErrorMessage = "Förnamn måste vara minst 2 tecken")]
    [MaxLength(50, ErrorMessage = "Förnamn får innehålla högst 50 tecken")]
    public string FName { get; set; } = string.Empty;
    [Required]
    [MinLength(2, ErrorMessage = "Efternamn måste vara minst 2 tecken")]
    [MaxLength(50, ErrorMessage = "Efternamn får innehålla högst 50 tecken")]
    public string LName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^(\+46|0)7\d{8}$", ErrorMessage = "Ogiltigt telefonnummer")] 
    public string PhoneNum { get; set; } = string.Empty;
}