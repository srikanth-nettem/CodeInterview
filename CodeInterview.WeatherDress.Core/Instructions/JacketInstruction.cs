using System;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class JacketInstruction : IInstruction
    {
        private readonly IWeatherDressing _weatherType;
        private readonly IStateManager _stateManager;

        public JacketInstruction(IWeatherDressing weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }

        public void Execute()
        {
            _weatherType.PutOnJacket();
        }
    }
}