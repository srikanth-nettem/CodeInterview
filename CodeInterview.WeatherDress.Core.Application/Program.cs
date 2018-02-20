using CodeInterview.WeatherDress.Core.io;
using System;

namespace CodeInterview.WeatherDress.Core.Application
{
    public class Program
    {

        private const char SPACE_VALUE = ' ';
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            
            var processor = new InstructionProcessor();

            writer.WriteLine("WELCOME TO WEATHER DRESSING.", ConsoleColor.White);
            writer.WriteLine("");
            while (true)
            {
                writer.WriteLine("1. Provide instructions: Sample - HOT 8, 6, 4, 2, 1, 7", ConsoleColor.White);
                writer.WriteLine("2. Input 'q' to Exit.", ConsoleColor.White);

                var instructionsValue = reader.ReadLine();

                if (instructionsValue.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;

                processor.Execute(String.Concat(instructionsValue," "));
            }
        }
    }
}
