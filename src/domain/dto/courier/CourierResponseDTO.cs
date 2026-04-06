public class CourierResponseDTO
{
    public int Id { get; init; }
    public string FName { get; init; } = string.Empty;
    public string LName { get; init; } = string.Empty;
    public string PhoneNum { get; init; } = string.Empty;
    public bool IsAvailable { get; init; }
}