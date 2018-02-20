using CodeInterview.WeatherDress.Core.WeatherType;
using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Exceptions;

namespace CodeInterview.WeatherDress.Core.Tests.WeatherType
{
    [Trait("Category", "unit")]
    public class HotWeatherTests
    {
        private readonly WeatherDressing _hotWeather;
        private readonly IWriter _writerMock;
        private readonly IDressValidator _dressValidator;

        public HotWeatherTests()
        {
            _writerMock = Substitute.For<IWriter>();
            _dressValidator = Substitute.For<IDressValidator>(); 
            _hotWeather = new HotWeatherDressing(_writerMock, _dressValidator);
            _dressValidator.isValid(DressCommand.PantsOn).ReturnsForAnyArgs(true);
        }

        [Fact(DisplayName = "Should Dress Shorts For Pants Command in Hot Weather.")]
        public void ShouldWearShortsWhenAskedToPutOnPants()
        {
            _hotWeather.PutOnPants();
            _writerMock.Received().Write("shorts");
        }

        [Fact(DisplayName = "Should throw NotSupportedDressException when asked to wear Jacket in Hot Weather")]
        public void ShouldFailOnJacketCommand()
        {
            Assert.Throws(typeof(NotSupportedDressException), ()=>_hotWeather.PutOnJacket());
        }

        [Fact(DisplayName = "Should throw NotSupportedDressException when asked to wear socks in Hot Weather")]
        public void ShouldFailOnSocksCommand()
        {
            Assert.Throws(typeof(NotSupportedDressException), () => _hotWeather.PutOnSocks());
        }

        [Fact(DisplayName = "Should Dress t-shirt For Shirt Command in Hot Weather.")]
        public void ShouldWearShirtWhenAskedToPutOnShirt()
        {
            _hotWeather.PutOnShirt();
            _writerMock.Received().Write("t-shirt");
        }

        [Fact(DisplayName = "Should wear sun-visor For Headwear Command in Hot Weather.")]
        public void ShouldWearsunvisorWhenAskedToPutOnHeadWear()
        {
            _hotWeather.PutOnHeadwear();
            _writerMock.Received().Write("sun visor");
        }

        [Fact(DisplayName = "Should wear sandals For Footwear Command in Hot Weather.")]
        public void ShouldWearSandalsWhenAskedToPutOnFootwear()
        {
            _hotWeather.PutOnFootwear();
            _writerMock.Received().Write("sandals");
        }

        [Fact(DisplayName = "Should take off pajamas on Pajamas_Off Command")]
        public void ShouldTakeOffPajamas()
        {
            _hotWeather.TakeOffPajamas();
            _writerMock.Received().Write("Removing PJs");
        }

        [Fact(DisplayName = "Should leave house on LeaveHouse Command")]
        public void ShouldLeaveHouse()
        {
            _hotWeather.LeaveHouse();
            _writerMock.Received().Write("leaving house");
        }

        [Fact(DisplayName = "Should throw WeatherDressRuleViolatedException when dressValidationRule fails.")]
        public void ShouldThrowInvalidDressInstructionException()
        {
            _dressValidator.isValid(DressCommand.FootwearOn).ReturnsForAnyArgs(false);
            Assert.Throws(typeof(WeatherDressRuleViolatedException), () => _hotWeather.PutOnFootwear());
        }
    }
}
