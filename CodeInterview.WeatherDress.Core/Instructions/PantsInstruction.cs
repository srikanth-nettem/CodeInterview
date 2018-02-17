using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class PantsInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public PantsInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.PutOnPants();
        }
    }
}