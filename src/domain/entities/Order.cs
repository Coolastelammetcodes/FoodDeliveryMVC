namespace domain.entities;
public class Order
{
    public Guid Id { get; init; } = Guid.NewGuid(); 
    public List<OrderItem> OrderItems { get; set; } = new();
    public string Instructions { get; set; } = string.Empty;
    public Customer Customer { get; set; } = new(); 

    // TODO lägg props för att mata in kunduppgifter här och skippa Customer klassen om inte du hinner göra färdigt Customer innan lördag
}