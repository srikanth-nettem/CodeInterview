using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class ShirtInstructionTests
    {
        private IDressInstruction _shirtInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public ShirtInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _shirtInstruction = new ShirtInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName ="should call PutOnShirt on Weather instance on execution.")]
        public void onExecute()
        {
            _shirtInstruction.Execute();
            _weatherMock.Received().PutOnShirt();
            _stateManager.Received().CurrentState = Dress.ShirtOn;
        }
    }
}
