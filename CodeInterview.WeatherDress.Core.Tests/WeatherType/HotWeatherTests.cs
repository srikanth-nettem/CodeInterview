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
            _hotWeather = new HotWeather(_writerMock, _dressValidator);
            _dressValidator.isValid(DressCommand.PantsOn).ReturnsForAnyArgs(true);
        }

        [Fact(DisplayName = "Should Dress Shorts For Pants Command in Hot Weather.")]
        public void ShouldWearShortsWhenAskedToPutOnPants()
        {
            _hotWeather.PutOnPants();
            _writerMock.Received().Write("shorts");
        }

        [Fact(DisplayName = "Should fail when asked to wear Jacket in Hot Weather")]
        public void ShouldFailOnJacketCommand()
        {
            Assert.Throws(typeof(InvalidDressInstructionException), ()=>_hotWeather.PutOnJacket());
        }

        [Fact(DisplayName = "Should fail when asked to wear socks in Hot Weather")]
        public void ShouldFailOnSocksCommand()
        {
            Assert.Throws(typeof(InvalidDressInstructionException), () => _hotWeather.PutOnSocks());
        }

        [Fact(DisplayName = "Should Dress shirt For Shirt Command in Hot Weather.")]
        public void ShouldWearShirtWhenAskedToPutOnShirt()
        {
            _hotWeather.PutOnShirt();
            _writerMock.Received().Write("shirt");
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

        [Fact(DisplayName = "Should throw NotSupportedDressException when dressValidationRule fails.")]
        public void ShouldThrowInvalidDressInstructionException()
        {
            _dressValidator.isValid(DressCommand.FootwearOn).ReturnsForAnyArgs(false);
            Assert.Throws(typeof(NotSupportedDressException), () => _hotWeather.PutOnFootwear());
        }
    }
}
