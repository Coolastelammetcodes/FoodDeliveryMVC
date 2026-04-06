using domain.enums;
namespace domain.entities;
public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid(); 
    public List<OrderItem> OrderItems { get; set; } = new();
    public string Instructions { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
    public int DeliveryFee { get; set; }
    public decimal ServiceFee { get; set; }
    public decimal TotalPrice { get; set; } 
    public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Received;
    public int CourierID { get; set; }
    public Courier? Courier { get; set; }

    // TODO Om du hinner lägg in så att användaren kan välja om hen vill spara sina uppgifter och först då använda Customertabellen men framtills dess behåll så att alla som lägger order sparas 
}