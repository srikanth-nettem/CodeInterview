using System;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class JacketInstruction : IInstruction
    {
        private readonly IWeatherType _weatherType;
        private readonly IStateManager _stateManager;

        public JacketInstruction(IWeatherType weatherType, IStateManager stateManager)
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