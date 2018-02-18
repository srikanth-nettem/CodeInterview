using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class FootwearInstructionTests
    {
        private IInstruction _footwearInstruction;
        private readonly IWeatherType _weatherMock;
        private readonly IStateManager _stateManager;
        public FootwearInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _stateManager = Substitute.For<IStateManager>();
            _footwearInstruction = new FootwearInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnFootwear on Weather instance on execution.")]
        public void onExecute()
        {
            _footwearInstruction.Execute();
            _weatherMock.Received().PutOnFootwear();
        }
    }
}