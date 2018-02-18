using System;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class HeadwearInstruction : IInstruction
    {
        private IWeatherType _weatherType;
        private readonly IStateManager _stateManager;
        public HeadwearInstruction(IWeatherType weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }

        public void Execute()
        {
            _stateManager.CurrentState = DressCommand.HeadwearOn;
            _weatherType.PutOnHeadwear();
        }
    }
}