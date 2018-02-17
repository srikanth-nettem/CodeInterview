using System;
using CodeInterview.WeatherDress.Core.WeatherType;


namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class JacketInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public JacketInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.PutOnJacket();
        }
    }
}