using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class JacketInstruction : IDressInstruction
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
            _stateManager.CurrentState = Dress.JacketOn;
            _weatherType.PutOnJacket();
        }
    }
}