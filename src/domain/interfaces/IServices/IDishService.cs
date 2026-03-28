using domain.dto.dish;
public interface IDishService
{
    Task<List<DishResponseDTO>> ViewAllDishesAsync();
    Task<DishResponseDTO> ViewSpecificDishAsync(int id);
    Task AddNewDishAsync(DishRequestDTO dishDTO);
}