using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class FootwearInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public FootwearInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.PutOnFootwear();
        }
    }
}