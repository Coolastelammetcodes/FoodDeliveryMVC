using domain.entities;
using domain.interfaces;

public class RestaurantService
{
    private readonly IRestaurantRepository _restaurantrepo;
    public RestaurantService(IRestaurantRepository restaurantrepo)
    {
        _restaurantrepo = restaurantrepo;
    }
    
    public async Task AddRestaurantAsync(AddRestaurantDTO dto)
    {
        var restaurant = new Restaurant
        (
            dto.Name,
            dto.Address,
            dto.PhoneNum,
            dto.Description,
            dto.Open,
            dto.Closed
        );

        await _restaurantrepo.AddNewRestaurantAsync(restaurant);
    }
}