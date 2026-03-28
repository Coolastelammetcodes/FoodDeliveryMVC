using domain.dto.dish;
public class DishService : IDishService
{
    private readonly IDishRepository _dishRepo;
    public DishService(IDishRepository dishRepo)
    {
        _dishRepo = dishRepo;
    }

    public async Task<List<DishResponseDTO>> ViewAllDishesAsync()
    {
        var dishes = await _dishRepo.ViewAllDishesAsync();

        return dishes.Select(d => new DishResponseDTO(
            d.Id,
            d.Name,
            d.Description,
            d.Price,
            d.RestaurantID
        )).ToList();
    }
    public async Task<DishResponseDTO> ViewSpecificDishAsync(int id)
    {
        var dish = await _dishRepo.ViewSpecificDishAsync(id);
        if(dish == null)
        {
            return null;
        }
        return new DishResponseDTO
        (
            dish.Id,
            dish.Name,
            dish.Description,
            dish.Price,
            dish.RestaurantID
        );
    }
    public async Task AddNewDishAsync(DishRequestDTO dishDTO){}
}