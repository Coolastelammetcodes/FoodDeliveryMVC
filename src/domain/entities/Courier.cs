using System.Data.Common;

public class Courier
{
    public int Id { get; set; }
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string PhoneNum { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
}