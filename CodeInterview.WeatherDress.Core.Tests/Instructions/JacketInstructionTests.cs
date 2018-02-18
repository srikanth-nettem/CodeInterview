using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class JacketInstructionTests
    {
        private IInstruction _jacketInstruction;
        private readonly IWeatherType _weatherMock;
        private readonly IStateManager _stateManager;

        public JacketInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherType>();
            _jacketInstruction = new JacketInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName ="should call PutOnJacket on Weather instance on execution.")]
        public void onExecute()
        {
            _jacketInstruction.Execute();
            _weatherMock.Received().PutOnJacket();
        }
    }
}
