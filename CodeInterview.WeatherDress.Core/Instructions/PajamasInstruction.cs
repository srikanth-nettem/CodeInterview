using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class PajamasInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public PajamasInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.TakeOffPajamas();
        }
    }
}