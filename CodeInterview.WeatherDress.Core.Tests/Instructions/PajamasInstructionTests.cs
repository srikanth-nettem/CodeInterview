using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class PajamasInstructionTests
    {
        private IInstruction _pajamasInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public PajamasInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _pajamasInstruction = new PajamasInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call TakeOffPajamas on Weather instance on execution.")]
        public void onExecute()
        {
            _pajamasInstruction.Execute();
            _weatherMock.Received().TakeOffPajamas();
            _stateManager.Received().CurrentState = DressCommand.Pajamas_Off;

        }
    }
}