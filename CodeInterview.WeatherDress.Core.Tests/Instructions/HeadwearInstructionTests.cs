using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class HeadwearInstructionTests
    {
        private IInstruction _headwearInstruction;
        private readonly IWeatherType _weatherMock;
        private readonly IStateManager _stateManager;

        public HeadwearInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherType>();
            _headwearInstruction = new HeadwearInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnHeadwear on Weather instance on execution.")]
        public void onExecute()
        {
            _headwearInstruction.Execute();
            _weatherMock.Received().PutOnHeadwear();
        }
    }
}