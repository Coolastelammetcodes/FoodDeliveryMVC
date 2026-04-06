using domain.dto;
using domain.entities;
using domain.interfaces;
public class DishService : IDishService
{
    private readonly IDishRepository _dishRepo;
    public DishService(IDishRepository dishRepo)
    {
        _dishRepo = dishRepo;
    }

    public async Task<List<DishResponseDTO>> GetDishesForRestaurantAsync(int restaurantID)
    {
        var restaurantDishes = await _dishRepo.GetDishesForRestaurantAsync(restaurantID);
        return restaurantDishes.Select(d => new DishResponseDTO{
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Price = d.Price,
            RestaurantID = d.RestaurantID
        }).ToList();
    }
    public async Task<List<DishResponseDTO>> ViewAllDishesAsync()
    {
        var dishes = await _dishRepo.ViewAllDishesAsync();

        return dishes.Select(d => new DishResponseDTO{
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Price = d.Price,
            RestaurantID = d.RestaurantID
        }).ToList();
    }
    public async Task<DishResponseDTO> ViewSpecificDishAsync(int id)
    {
        var dish = await _dishRepo.ViewSpecificDishAsync(id);
        if(dish == null)
        {
            return null;
        }
        return new DishResponseDTO
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            RestaurantID = dish.RestaurantID
        };
    }
    public async Task AddNewDishAsync(DishRequestDTO dishDTO)
    {
        var newDish = new Dish
        {
            Name = dishDTO.Name,
            Description = dishDTO.Description,
            Price = dishDTO.Price,
            RestaurantID = dishDTO.RestaurantID
        };
        await _dishRepo.AddNewDishAsync(newDish);
    }
}