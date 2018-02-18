using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class HeadwearInstructionTests
    {
        private IInstruction _headwearInstruction;
        private IWeatherType _weatherMock;

        public HeadwearInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _headwearInstruction = new HeadwearInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call PutOnHeadwear on Weather instance on execution.")]
        public void onExecute()
        {
            _headwearInstruction.Execute();
            _weatherMock.Received().PutOnHeadwear();
        }
    }
}