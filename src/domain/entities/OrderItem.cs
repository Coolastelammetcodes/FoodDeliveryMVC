namespace domain.entities;
public class OrderItem
{
    public int Id { get; set; }
    public int DishID { get; set; }
    public int Quantity { get; set; }
    public OrderItem(int dishID, int quantity)
    {
        DishID = dishID;
        Quantity = quantity;
    }
}