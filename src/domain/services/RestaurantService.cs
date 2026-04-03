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
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Address = restaurant.Address,
            Description = restaurant.Description,
            Open = restaurant.Open,
            Closed = restaurant.Closed,
            OrderDeadline = restaurant.OrderDeadline
        };
    }
    public async Task<List<RestaurantResponseDTO>> ViewAllRestaurantsAsync() 
    {
        var restaurants = await _restaurantrepo.ViewAllRestaurantsAsync();
        
        return restaurants.Select(r => new RestaurantResponseDTO{
            Id= r.Id,
            Name = r.Name,
            Address = r.Address,
            Description = r.Description,
            Open = r.Open,
            Closed = r.Closed,
            OrderDeadline = r.OrderDeadline
        }).ToList();
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