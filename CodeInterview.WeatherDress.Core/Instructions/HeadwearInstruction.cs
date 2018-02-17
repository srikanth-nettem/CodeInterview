using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class HeadwearInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public HeadwearInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.PutOnHeadwear();
        }
    }
}