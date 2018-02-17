using System;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class LeaveHouseInstruction : IInstruction
    {
        private IWeatherType _weatherType;

        public LeaveHouseInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }

        public void Execute()
        {
            _weatherType.LeaveHouse();
        }
    }
}