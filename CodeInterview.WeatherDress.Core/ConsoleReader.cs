using System;

namespace CodeInterview.WeatherDress.Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
