using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class FootwearInstructionTests
    {
        private IDressInstruction _footwearInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;
        public FootwearInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherDressing>();
            _stateManager = Substitute.For<IStateManager>();
            _footwearInstruction = new FootwearInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnFootwear on Weather instance on execution.")]
        public void onExecute()
        {
            _footwearInstruction.Execute();
            _weatherMock.Received().PutOnFootwear();
            _stateManager.Received().CurrentState = Dress.FootwearOn;
        }
        
    }
}