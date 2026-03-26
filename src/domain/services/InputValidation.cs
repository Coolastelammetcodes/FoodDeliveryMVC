public class InputValidation
{
    public async Task<bool> IsValidStringInput(string value) // TODO fortsätt med valideringen senare
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new Exception("Vänligen fyll i detta fält för att gå vidare");
        }
        if(value.Length > 100)
        {
             return false;
        }
        return true;
    }
}