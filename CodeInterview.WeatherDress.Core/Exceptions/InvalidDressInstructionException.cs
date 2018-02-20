using System;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class InvalidDressInstructionException:Exception
    {
        public InvalidDressInstructionException(string message):base(message)
        {
        }
    }
}
