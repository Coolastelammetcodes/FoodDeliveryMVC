using domain.dto;
using domain.entities;

public class OrderCalculationResultDTO
{
    public List<OrderItem> OrderItems { get; set; } = new();
    public int DeliveryFee { get; set; }
    public decimal ServiceFee { get; set; }
    public decimal TotalPrice { get; set; }
}