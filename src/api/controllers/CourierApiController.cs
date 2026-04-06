using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CourierApiController : ControllerBase
{
    private readonly ICourierService _courierService;
    public CourierApiController(ICourierService courierService)
    {
        _courierService = courierService;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewCourierAsync(CourierRequestDTO reqDTO)
    {   
        try
        {
            await _courierService.AddNewCourierAsync(reqDTO);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        } 
    }
    [HttpGet]
    public async Task<IActionResult> ViewAllCouriersAsync()
    {
        var couriers = await _courierService.ViewAllCouriersAsync();
        
        if(couriers == null) return NotFound();
        
        return Ok(couriers);
    }
}