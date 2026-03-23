using domain.entities;
using domain.interfaces;

public class RestaurantService
{
    private readonly IRestaurantRepository _restaurant;
    public RestaurantService(IRestaurantRepository restaurant)
    {
        _restaurant = restaurant;
    }
    
}