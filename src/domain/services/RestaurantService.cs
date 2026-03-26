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
        var restaurants = await _restaurantrepo.ViewAllRestaurantsAsync();
        if(restaurants == null)
        {
            throw new Exception("Could not find any restaurants");
        }
        return restaurants;
    }
    public async Task AddRestaurantAsync(AddRestaurantDTO dto)
    {
        var restaurant = new Restaurant
        (
            dto.Name,
            dto.Address,
            dto.Description,
            dto.Open,
            dto.Closed,
            dto.OrderDeadline

        );

        await _restaurantrepo.AddNewRestaurantAsync(restaurant);
    }
}