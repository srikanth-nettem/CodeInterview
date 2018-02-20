using CodeInterview.WeatherDress.Core.Utils;
namespace CodeInterview.WeatherDress.Core.Validations
{
    public interface IDressValidator
    {
        bool isValid(Dress dressCommand);
    }
}
