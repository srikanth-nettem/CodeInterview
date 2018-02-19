using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core
{
    public class ConsoleWriter : IWriter
    {
        private bool _started;
        public void Write(string statement)
        {
            if (_started)
            {
                statement = string.Concat(", ", statement);
            }else
            {
                _started = true;
            }
            Console.Write(statement);
        }

        public void WriteLine(string statement)
        {
            Console.WriteLine(statement);
        }
    }
}
