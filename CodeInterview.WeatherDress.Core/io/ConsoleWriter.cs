using System;

namespace CodeInterview.WeatherDress.Core.io
{
    public class ConsoleWriter : IWriter
    {

        private bool written = false;

        public void Write(string statement, ConsoleColor consoleColor=ConsoleColor.Green)
        {
            Console.ForegroundColor = consoleColor;

            if (!written)
            {
                written = !written;
                statement = string.Format("Output: {0}", statement.Replace(",",string.Empty).Trim());
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
