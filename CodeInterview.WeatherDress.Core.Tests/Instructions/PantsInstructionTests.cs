using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class PantsInstructionTests
    {
        private IInstruction _pantsInstruction;
        private IWeatherType _weatherMock;

        public PantsInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _pantsInstruction = new PantsInstruction(_weatherMock);
        }

        [Fact(DisplayName = "should call PutOnPants on Weather instance on execution.")]
        public void onExecute()
        {
            _pantsInstruction.Execute();
            _weatherMock.Received().PutOnPants();
        }
    }
}