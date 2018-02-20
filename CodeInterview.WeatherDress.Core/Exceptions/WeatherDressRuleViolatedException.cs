using System;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class WeatherDressRuleViolatedException:Exception
    {
        public WeatherDressRuleViolatedException():base()
        {

        }

        public WeatherDressRuleViolatedException(string message):base(message)
        {

        }
    }
}
