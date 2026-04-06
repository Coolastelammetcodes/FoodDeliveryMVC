using System.Net.Http.Headers;

namespace domain.entities;
public class OrderItem
{
    public int Id { get; set; }
    public int DishID { get; set; }
    public int Quantity { get; set; }
    public Dish? Dish { get; set; }
}