using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.io
{
    public class ConsoleWriter : IWriter
    {
        private bool _started;

        public void Write(string statement, ConsoleColor consoleColor=ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;

            if (_started)
            {
                statement = string.Concat(", ", statement);
            }else
            {
                _started = true;
                statement = string.Format("Output: {0}", statement);
            }
            Console.Write(statement);
        }

        public void WriteLine(string statement, ConsoleColor consoleColor = ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(statement);
        }
    }
}
