using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class PajamasInstructionTests
    {
        private IInstruction _pajamasInstruction;
        private IWeatherType _weatherMock;

        public PajamasInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _pajamasInstruction = new PajamasInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call TakeOffPajamas on Weather instance on execution.")]
        public void onExecute()
        {
            _pajamasInstruction.Execute();
            _weatherMock.Received().TakeOffPajamas();
        }
    }
}