using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class ShirtInstructionTests
    {
        private IInstruction _shirtInstruction;
        private IWeatherType _weatherMock;

        public ShirtInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _shirtInstruction = new ShirtInstruction(_weatherMock);
        }

        [Fact(DisplayName ="should call PutOnShirt on Weather instance on execution.")]
        public void onExecute()
        {
            _shirtInstruction.Execute();
            _weatherMock.Received().PutOnShirt();
        }
    }
}
