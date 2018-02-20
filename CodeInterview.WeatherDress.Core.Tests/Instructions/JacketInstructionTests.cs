using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class JacketInstructionTests
    {
        private IDressInstruction _jacketInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public JacketInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _jacketInstruction = new JacketInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName ="should call PutOnJacket on Weather instance on execution.")]
        public void onExecute()
        {
            _jacketInstruction.Execute();
            _stateManager.Received().CurrentState = Dress.JacketOn;
            _weatherMock.Received().PutOnJacket();
        }
    }
}
