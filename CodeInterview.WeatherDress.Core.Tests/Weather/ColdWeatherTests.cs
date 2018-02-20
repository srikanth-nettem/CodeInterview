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
    public class ColdWeatherTests
    {
        private readonly WeatherDressing _coldWeather;
        private readonly IWriter _writerMock;
        private readonly IDressValidator _dressValidator;

        public ColdWeatherTests()
        {
            _writerMock = Substitute.For<IWriter>();
            _dressValidator = Substitute.For<IDressValidator>();
            _coldWeather = new ColdWeatherDressing(_writerMock, _dressValidator);
            _dressValidator.isValid(Dress.Pajamas_Off).ReturnsForAnyArgs(true);
        }

        [Fact(DisplayName = "Should take off pajamas on Pajamas_Off Command")]
        public void ShouldTakeOffPajamas()
        {
            _coldWeather.TakeOffPajamas();
            _writerMock.Received().Write("Removing PJs");
        }

        [Fact(DisplayName = "Should leave house on LeaveHouse Command")]
        public void ShouldLeaveHouse()
        {
            _coldWeather.LeaveHouse();
            _dressValidator.Received().isValid(Dress.LeaveHouse);
            _writerMock.Received().Write(Constants.LEAVING_HOME);
        }

        [Fact(DisplayName = "Should Dress pants on Pants Command in Cold Weather.")]
        public void ShouldWearShortsWhenAskedToPutOnPants()
        {
            _coldWeather.PutOnPants();
            _dressValidator.Received().isValid(Dress.PantsOn);
            _writerMock.Received().Write(Constants.PANTS);
        }

        [Fact(DisplayName = "Should wear jacket on Jacket Command in Cold Weather")]
        public void ShouldFailOnJacketCommand()
        {
            _coldWeather.PutOnJacket();
            _dressValidator.Received().isValid(Dress.JacketOn);
            _writerMock.Received().Write(Constants.JACKET);
        }

        [Fact(DisplayName = "Should Wear socks on Socks Command in Cold Weather")]
        public void ShouldFailOnSocksCommand()
        {
            _coldWeather.PutOnSocks();
            _dressValidator.Received().isValid(Dress.SocksOn);
            _writerMock.Received().Write(Constants.SOCKS);
        }

        [Fact(DisplayName = "Should Dress shirt For Shirt Command in Cold Weather.")]
        public void ShouldWearShirtWhenAskedToPutOnShirt()
        {
            _coldWeather.PutOnShirt();
            _dressValidator.Received().isValid(Dress.ShirtOn);
            _writerMock.Received().Write(Constants.SHIRT);
        }

        [Fact(DisplayName = "Should wear hat For Headwear Command in Cold Weather.")]
        public void ShouldWearHatWhenAskedToPutOnHeadWear()
        {
            _coldWeather.PutOnHeadwear();
            _dressValidator.Received().isValid(Dress.HeadwearOn);
            _writerMock.Received().Write(Constants.HAT);
        }

        [Fact(DisplayName = "Should wear boots For Footwear Command in Cold Weather.")]
        public void ShouldWearBootsWhenAskedToPutOnFootwear()
        {
            _coldWeather.PutOnFootwear();
            _dressValidator.Received().isValid(Dress.FootwearOn);
            _writerMock.Received().Write(Constants.BOOTS);
        }

        [Fact(DisplayName = "Should throw WeatherDressRuleViolatedException when dressValidationRule fails.")]
        public void ShouldThrowInvalidDressInstructionException()
        {
            _dressValidator.isValid(Dress.FootwearOn).Returns(false);
            Assert.Throws(typeof(WeatherDressRuleViolatedException), () => _coldWeather.PutOnFootwear());
        }
    }
}
