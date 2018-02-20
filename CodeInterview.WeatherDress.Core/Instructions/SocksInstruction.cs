using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class SocksInstruction : IDressInstruction
    {
        private readonly IWeatherDressing _weatherType;
        private readonly IStateManager _stateManager;
        public SocksInstruction(IWeatherDressing weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }

        public void Execute()
        {
            _stateManager.CurrentState = Dress.SocksOn;
            _weatherType.PutOnSocks();
        }
    }
}