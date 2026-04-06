using domain.dto;
using Swashbuckle.AspNetCore.Filters;

public class CourierRequestPlaceholder : IExamplesProvider<CourierRequestDTO>
{
    public CourierRequestDTO GetExamples()
    {
        return new CourierRequestDTO
        {
            FName = "Budets förnamn",
            LName = "Budets efternamn",
            PhoneNum = "0700000000"
        };
    }
}