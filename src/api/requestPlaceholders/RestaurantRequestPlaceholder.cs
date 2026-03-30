using domain.dto;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.Filters;

public class RestaurantRequestPlaceholder : IExamplesProvider<RestaurantRequestDTO>
{
    public RestaurantRequestDTO GetExamples()
    {
        return new RestaurantRequestDTO
        {
            Name = "Restaurangens namn",
            Address = "Gata, stad",
            Description = "Kort beskrivning om restaurangen",
            Open = new TimeSpan(09,00,0),
            Closed = new TimeSpan(21,00,0),
            OrderDeadline = new TimeSpan(20,45,0)
        };
    }
}