using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class NotSupportedDressException:Exception
    {
        public NotSupportedDressException(string message):base(message)
        {
        }
    }
}
