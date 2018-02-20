using System;

namespace CodeInterview.WeatherDress.Core.io
{
    public interface IWriter
    {
        void Write(string statement, ConsoleColor consoleColor = ConsoleColor.Green);

        void WriteLine(string statement, ConsoleColor consoleColor = ConsoleColor.Green);
    }
}
