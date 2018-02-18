namespace CodeInterview.WeatherDress.Core.Validations
{
    public interface IDressValidator
    {
        bool isValid(DressCommand dressCommand);
    }
}
