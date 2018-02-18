using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.Exceptions
{
    public class InvalidDressInstructionException:Exception
    {
        public InvalidDressInstructionException(string message):base(message)
        {
        }
    }
}
