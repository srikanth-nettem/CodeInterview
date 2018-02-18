using System;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class PantsInstruction : IInstruction
    {
        private readonly IWeatherType _weatherType;
        private readonly IStateManager _stateManager;

        public PantsInstruction(IWeatherType weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }

        public void Execute()
        {
            _stateManager.CurrentState = DressCommand.PantsOn;
            _weatherType.PutOnPants();
        }
    }
}