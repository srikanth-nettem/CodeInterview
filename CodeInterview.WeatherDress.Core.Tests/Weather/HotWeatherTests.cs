using CodeInterview.WeatherDress.Core.Weather;
using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Weather
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
            _dressValidator.isValid(Dress.PantsOn).ReturnsForAnyArgs(true);
        }

        [Fact(DisplayName = "Should Dress Shorts For Pants Command in Hot Weather.")]
        public void ShouldWearShortsWhenAskedToPutOnPants()
        {
            _hotWeather.PutOnPants();
            _dressValidator.Received().isValid(Dress.PantsOn);
            _writerMock.Received().Write(Constants.SHORTS);
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
            _dressValidator.Received().isValid(Dress.ShirtOn);
            _writerMock.Received().Write(Constants.TSHIRT);
        }

        [Fact(DisplayName = "Should wear sun-visor For Headwear Command in Hot Weather.")]
        public void ShouldWearsunvisorWhenAskedToPutOnHeadWear()
        {
            _hotWeather.PutOnHeadwear();
            _dressValidator.Received().isValid(Dress.HeadwearOn);
            _writerMock.Received().Write(Constants.SUN_VISOR);
        }

        [Fact(DisplayName = "Should wear sandals For Footwear Command in Hot Weather.")]
        public void ShouldWearSandalsWhenAskedToPutOnFootwear()
        {
            _hotWeather.PutOnFootwear();
            _dressValidator.Received().isValid(Dress.FootwearOn);
            _writerMock.Received().Write(Constants.SANDALS);
        }

        [Fact(DisplayName = "Should take off pajamas on Pajamas_Off Command")]
        public void ShouldTakeOffPajamas()
        {
            _hotWeather.TakeOffPajamas();
            _dressValidator.Received().isValid(Dress.Pajamas_Off);
            _writerMock.Received().Write(Constants.PAJAMAS_OFF);
        }

        [Fact(DisplayName = "Should leave house on LeaveHouse Command")]
        public void ShouldLeaveHouse()
        {
            _hotWeather.LeaveHouse();
            _dressValidator.Received().isValid(Dress.LeaveHouse);
            _writerMock.Received().Write(Constants.LEAVING_HOME);
        }

        [Fact(DisplayName = "Should throw WeatherDressRuleViolatedException when dressValidationRule fails.")]
        public void ShouldThrowInvalidDressInstructionException()
        {
            _dressValidator.isValid(Dress.FootwearOn).ReturnsForAnyArgs(false);
            Assert.Throws(typeof(WeatherDressRuleViolatedException), () => _hotWeather.PutOnFootwear());
        }
    }
}
