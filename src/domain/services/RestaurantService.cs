using domain.entities;
using domain.interfaces;

public class RestaurantService
{
    private readonly IRestaurantRepository _restaurantrepo;
    public RestaurantService(IRestaurantRepository restaurantrepo)
    {
        _restaurantrepo = restaurantrepo;
    }
    
    public async Task AddRestaurantAsync(CreateRestaurantDTO dto)
    {
        var restaurant = new Restaurant
        (
            dto.Name,
            dto.Address,
            dto.PhoneNum,
            dto.Open,
            dto.Closed,
            dto.Description
        );

        await _restaurantrepo.AddNewRestaurantAsync(restaurant);
    }
}