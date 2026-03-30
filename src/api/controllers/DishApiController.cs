using domain.dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class DishApiController : ControllerBase
{
    private readonly IDishService _dishService;
    public DishApiController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewDish(DishRequestDTO dto)
    {
        await _dishService.AddNewDishAsync(dto);
        return Created();
    }
}