using System;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class InvalidWeatherInstructionException:Exception
    {
        public InvalidWeatherInstructionException(string message):base(message)
        {
        }
    }
}
