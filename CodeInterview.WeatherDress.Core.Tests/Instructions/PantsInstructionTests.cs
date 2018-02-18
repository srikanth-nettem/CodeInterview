using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class PantsInstructionTests
    {
        private IInstruction _pantsInstruction;
        private readonly IWeatherType _weatherMock;
        private readonly IStateManager _stateManager;

        public PantsInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherType>();
            _pantsInstruction = new PantsInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnPants on Weather instance on execution.")]
        public void onExecute()
        {
            _pantsInstruction.Execute();
            _weatherMock.Received().PutOnPants();
        }
    }
}