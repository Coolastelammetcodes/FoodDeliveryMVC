namespace domain.dto;
public class OrderItemDishResponseDTO
{
    public int Id { get; init; }
    public int DishID { get; init; }
    public int Quantity { get; init;}
    public string DishName { get; init; } = string.Empty;
    public int DishPrice { get; init; } 

    public OrderItemDishResponseDTO(int id, int dishID, int quantity, string dishName, int dishPrice)
    {
        Id = id;
        DishID = dishID;
        Quantity = quantity;
        DishName = dishName;
        DishPrice = dishPrice;
    }
}