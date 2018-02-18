using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class SocksInstructionTests
    {
        private IInstruction _socksInstruction;
        private IWeatherType _weatherMock;

        public SocksInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _socksInstruction = new SocksInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call PutOnSocks on Weather instance on execution.")]
        public void onExecute()
        {
            _socksInstruction.Execute();
            _weatherMock.Received().PutOnSocks();
        }
    }
}