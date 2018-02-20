using System;

namespace CodeInterview.WeatherDress.Core.io
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine();
        }
    }
}
