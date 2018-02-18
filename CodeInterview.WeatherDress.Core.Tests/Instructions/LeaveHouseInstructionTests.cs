using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class LeaveHouseInstructionTests
    {
        private IInstruction _leaveHouseInstruction;
        private IWeatherType _weatherMock;

        public LeaveHouseInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _leaveHouseInstruction = new LeaveHouseInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call leavehouse on Weather instance on execution.")]
        public void onExecute()
        {
            _leaveHouseInstruction.Execute();
            _weatherMock.Received().LeaveHouse();
        }
    }
}