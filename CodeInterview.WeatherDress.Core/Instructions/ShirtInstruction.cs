using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class ShirtInstruction : IInstruction
    {
        private readonly IWeatherDressing _weatherType;
        private readonly IStateManager _stateManager;
        public ShirtInstruction(IWeatherDressing weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }
        public void Execute()
        {
            _stateManager.CurrentState = DressCommand.ShirtOn;
            _weatherType.PutOnShirt();
        }
    }
}
