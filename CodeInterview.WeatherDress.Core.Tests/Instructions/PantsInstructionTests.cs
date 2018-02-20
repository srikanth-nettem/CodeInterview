using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class PantsInstructionTests
    {
        private IDressInstruction _pantsInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public PantsInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _pantsInstruction = new PantsInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnPants on Weather instance on execution.")]
        public void onExecute()
        {
            _pantsInstruction.Execute();
            _weatherMock.Received().PutOnPants();
            _stateManager.Received().CurrentState = Dress.PantsOn;

        }
    }
}