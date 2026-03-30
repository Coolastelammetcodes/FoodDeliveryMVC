using domain.entities;
using domain.interfaces;
using domain.dto;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantrepo;
    public RestaurantService(IRestaurantRepository restaurantrepo)
    {
        _restaurantrepo = restaurantrepo;
    }
    
    public async Task<RestaurantResponseDTO> ViewSpecificRestaurant(int id)
    {
        var restaurant = await _restaurantrepo.GetRestaurantByIdAsync(id);
        if(restaurant == null)
        {
            return null;
        }
        return new RestaurantResponseDTO
        (
            restaurant.Id,
            restaurant.Name,
            restaurant.Address,
            restaurant.Description,
            restaurant.Open,
            restaurant.Closed,
            restaurant.OrderDeadline
        );
    }
    public async Task<List<RestaurantResponseDTO>> ViewAllRestaurantsAsync() 
    {
        var restaurants = await _restaurantrepo.ViewAllRestaurantsAsync();
        
        return restaurants.Select(r => new RestaurantResponseDTO(
            r.Id,
            r.Name,
            r.Address,
            r.Description,
            r.Open,
            r.Closed,
            r.OrderDeadline
        )).ToList();
    }
    public async Task AddRestaurantAsync(RestaurantRequestDTO dto)
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