/*using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using Xunit;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class JacketInstructionTests
    {
        private IInstruction _jacketInstruction;
        private IWeatherType _weatherMock;

        public JacketInstructionTests()
        {
            _weatherMock = Substitute.For<IWeatherType>();
            _jacketInstruction = new JacketInstruction(_weatherMock);
        }

        [Fact(DisplayName ="should call PutOnJacket on Weather instance on execution.")]
        public void onExecute()
        {
            _jacketInstruction.Execute();
            _weatherMock.Received().PutOnJacket();
        }
    }
}
*/