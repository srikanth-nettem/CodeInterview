using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
