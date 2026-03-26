using domain.entities;
using domain.interfaces;
using SQLitePCL;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantrepo;
    public RestaurantService(IRestaurantRepository restaurantrepo)
    {
        _restaurantrepo = restaurantrepo;
    }
    
    public async Task<List<Restaurant>> ViewAllRestaurantsAsync()
    {
        return await _restaurantrepo.ViewAllRestaurantsAsync();
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