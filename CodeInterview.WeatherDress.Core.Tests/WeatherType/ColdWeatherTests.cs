﻿using CodeInterview.WeatherDress.Core.WeatherType;
using Xunit;
using NSubstitute;

namespace CodeInterview.WeatherDress.Core.Tests.WeatherType
{
    
    [Trait("Category", "unit")]
    public class ColdWeatherTests
    {
        private IWeatherType _coldWeather;
        private IWriter _writerMock;

        public ColdWeatherTests()
        {
            _writerMock = Substitute.For<IWriter>();
            _coldWeather = new ColdWeather(_writerMock);
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
            _writerMock.Received().Write("leaving house");
        }

        [Fact(DisplayName = "Should Dress pants on Pants Command in Cold Weather.")]
        public void ShouldWearShortsWhenAskedToPutOnPants()
        {
            _coldWeather.PutOnPants();
            _writerMock.Received().Write("pants");
        }

        [Fact(DisplayName = "Should wear jacket on Jacket Command in Cold Weather")]
        public void ShouldFailOnJacketCommand()
        {
            _coldWeather.PutOnJacket();
            _writerMock.Received().Write("jacket");
        }

        [Fact(DisplayName = "Should Wear socks on Socks Command in Cold Weather")]
        public void ShouldFailOnSocksCommand()
        {
            _coldWeather.PutOnSocks();
            _writerMock.Received().Write("socks");
        }

        [Fact(DisplayName = "Should Dress t-shirt For Shirt Command in Cold Weather.")]
        public void ShouldWearShirtWhenAskedToPutOnShirt()
        {
            _coldWeather.PutOnShirt();
            _writerMock.Received().Write("t-shirt");
        }

        [Fact(DisplayName = "Should wear hat For Headwear Command in Cold Weather.")]
        public void ShouldWearsunvisorWhenAskedToPutOnHeadWear()
        {
            _coldWeather.PutOnHeadwear();
            _writerMock.Received().Write("hat");
        }

        [Fact(DisplayName = "Should wear boots For Footwear Command in Cold Weather.")]
        public void ShouldWearSandalsWhenAskedToPutOnFootwear()
        {
            _coldWeather.PutOnFootwear();
            _writerMock.Received().Write("boots");
        }
    }
}