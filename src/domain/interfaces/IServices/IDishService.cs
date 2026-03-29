using domain.dto;
public interface IDishService
{
    Task<List<DishResponseDTO>> GetDishesForRestaurantAsync(int restaurantID);
    Task<List<DishResponseDTO>> ViewAllDishesAsync();
    Task<DishResponseDTO> ViewSpecificDishAsync(int id);
    Task AddNewDishAsync(DishRequestDTO dishDTO);
}