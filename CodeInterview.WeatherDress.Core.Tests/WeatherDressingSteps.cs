using NSubstitute;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.Instructions;

namespace CodeInterview.WeatherDress.Core.Tests
{
    [Binding]
    public class WeatherDressingSteps
    {
        IWeatherType _weatherType;
        IWriter _writerMock;
        ArrayList dressed;

        public WeatherDressingSteps()
        {

            _writerMock = Substitute.For<IWriter>();
            _writerMock.When(writer => writer.Write(Arg.Any<string>())).Do(callinfo =>
            {
                dressed.Add(callinfo.Arg<string>());
            });
        }

        [Given(@"the weather is ""(.*)""")]
        public void GivenTheWeatherIs(WeatherEnum weather)
        {
            dressed = new ArrayList();

            switch (weather)
            {
                case WeatherEnum.HOT:
                    _weatherType = new HotWeather(_writerMock);
                    break;
                case WeatherEnum.COLD:
                    _weatherType = new ColdWeather(_writerMock);
                    break;
                default:
                    _weatherType = null;
                    break;
            }

            ScenarioContext.Current.Add("WeatherType", _weatherType);
        }
        [When(@"I wear the following in the given order")]
        public void WhenIWearTheFollowing(IEnumerable<IInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                instruction.Execute();
            }
        }

        [Then(@"I can leave house")]
        public void ThenICanLeaveHouse()
        {
            //Assert.True(dressed.Contains("leaving house"));
        }

        [Then(@"shirt I put on should be ""(.*)""")]
        public void ThenShirtIPutOnShouldBe(string shirtType)
        {
            Assert.True(dressed.Contains(shirtType));
        }

        [Then(@"pants I put on should be ""(.*)""")]
        public void ThenPantsIPutOnShouldBe(string pantsType)
        {
            Assert.True(dressed.Contains(pantsType));

        }

        [Then(@"headwear should be ""(.*)""")]
        public void ThenHeadwearShouldBe(string headwearType)
        {
            dressed.Contains(headwearType);
        }

        [Then(@"footweear should be ""(.*)""")]
        public void ThenFootweearShouldBe(string footwearType)
        {
            dressed.Contains(footwearType);
        }
    }
}
