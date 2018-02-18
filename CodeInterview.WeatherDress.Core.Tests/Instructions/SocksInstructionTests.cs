using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class SocksInstructionTests
    {
        private IInstruction _socksInstruction;
        private readonly IWeatherType _weatherMock;
        private readonly IStateManager _stateManager;

        public SocksInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherType>();
            _socksInstruction = new SocksInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnSocks on Weather instance on execution.")]
        public void onExecute()
        {
            _socksInstruction.Execute();
            _weatherMock.Received().PutOnSocks();
        }
    }
}