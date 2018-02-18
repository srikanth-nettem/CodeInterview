using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class FootwearInstructionTests
    {
        private IInstruction _footwearInstruction;
        private IWeatherType _weatherMock;

        public FootwearInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _footwearInstruction = new FootwearInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call PutOnFootwear on Weather instance on execution.")]
        public void onExecute()
        {
            _footwearInstruction.Execute();
            _weatherMock.Received().PutOnFootwear();
        }
    }
}