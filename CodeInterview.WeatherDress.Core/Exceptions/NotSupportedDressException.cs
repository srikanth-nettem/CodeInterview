using System;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class NotSupportedDressException:Exception
    {
        public NotSupportedDressException(string message):base(message)
        {
        }
    }
}
