using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class LeaveHouseInstructionTests
    {
        private IDressInstruction _leaveHouseInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public LeaveHouseInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _leaveHouseInstruction = new LeaveHouseInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call leavehouse on Weather instance on execution.")]
        public void onExecute()
        {
            _leaveHouseInstruction.Execute();
            _weatherMock.Received().LeaveHouse();
            _stateManager.Received().CurrentState = DressCommand.LeaveHouse;
        }
    }
}