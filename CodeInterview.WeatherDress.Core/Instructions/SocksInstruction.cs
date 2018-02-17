using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class SocksInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public SocksInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.PutOnSocks();
        }
    }
}