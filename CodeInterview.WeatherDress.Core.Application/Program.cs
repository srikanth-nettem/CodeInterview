using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Utils;
using System;

namespace CodeInterview.WeatherDress.Core.Application
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            
            var processor = new InstructionProcessor();

            writer.WriteLine("WELCOME TO WEATHER DRESSING.", ConsoleColor.White);
            writer.WriteLine(string.Empty);

            writer.WriteLine("Please use the below information to instruct for appropriate dressing", ConsoleColor.DarkGray);

            while (true)
            {
                writer.WriteLine("a) Provide instructions in the format - WEATHER DRESS-COMMANDS-COMMA-SEPERATED", ConsoleColor.White);
                writer.WriteLine("   Sample: HOT 8, 6, 4, 2, 1, 7", ConsoleColor.White);
                writer.WriteLine("b) Enter 'q' to Exit.", ConsoleColor.White);

                var instructionsValue = reader.ReadLine();

                if (instructionsValue.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                processor.Execute(string.Concat(instructionsValue,Constants.SPACE_CHAR));
            }
        }
    }
}
