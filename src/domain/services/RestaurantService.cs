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
    
    public async Task<List<ViewRestaurantDTO>> ViewAllRestaurantsAsync() // TODO använd ViewRestaurantDTO här
    {
        var restaurants = await _restaurantrepo.ViewAllRestaurantsAsync();
        
        return restaurants.Select(r => new ViewRestaurantDTO(
            r.Id,
            r.Name,
            r.Address,
            r.Description,
            r.Open,
            r.Closed,
            r.OrderDeadline
        )).ToList();
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