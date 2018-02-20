using System;

namespace CodeInterview.WeatherDress.Core.Application
{
    public class Program
    {

        private const char SPACE_VALUE = ' ';
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            var processor = new InstructionProcessor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Weather Dressing.");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Provide instructions: Sample - HOT 8, 6, 4, 2, 1, 7");
                Console.WriteLine("2. Input 'q' to Exit.");
                Console.ForegroundColor = ConsoleColor.DarkGray;

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
