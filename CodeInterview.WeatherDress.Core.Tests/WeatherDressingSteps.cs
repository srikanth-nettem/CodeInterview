using NSubstitute;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.Validations;

namespace CodeInterview.WeatherDress.Core.Tests
{
    [Binding]
    public class WeatherDressingSteps
    {
       private WeatherDressing _weatherType;
       private readonly IWriter _writerMock;
       private List<string> dressed;
       private readonly IStateManager _stateManager;
       private readonly IRulesEngine _rulesEngine;
       private readonly IDressValidator _dressValidator;
       private  IWeatherRules _hotWeatherRules;
       private  IWeatherRules _coldWeatherRules;

        public WeatherDressingSteps()
        {
            _rulesEngine = new RulesEngine();
            _stateManager = new StateManager();
            _dressValidator = new DressValidator(_rulesEngine, _stateManager);
            _writerMock = Substitute.For<IWriter>();
            _writerMock.When(writer => writer.Write(Arg.Any<string>())).Do(callinfo =>
            {
                dressed.Add(callinfo.Arg<string>());
            });
            ScenarioContext.Current.Add("DressState", _stateManager);
        }

        [Given(@"the weather is ""(.*)""")]
        public void GivenTheWeatherIs(WeatherEnum weather)
        {
            dressed = new List<string>();
            Console.WriteLine(dressed.ToArray());
            switch (weather)
            {
                case WeatherEnum.HOT:
                    _rulesEngine.ClearRules();
                    _hotWeatherRules = new HotWeatherRules(_rulesEngine);
                    _hotWeatherRules.ConfigureRules();
                    _weatherType = new HotWeatherDressing(_writerMock, _dressValidator);
                    break;
                case WeatherEnum.COLD:
                    _rulesEngine.ClearRules();
                    _coldWeatherRules = new ColdWeatherRules(_rulesEngine);
                    _coldWeatherRules.ConfigureRules();
                    _weatherType = new ColdWeatherDressing(_writerMock, _dressValidator);
                    break;
                default:
                    _weatherType = null;
                    break;
            }

            ScenarioContext.Current.Add("WeatherType", _weatherType);
        }

        [When(@"I wear the following in the given order")]
        public void WhenIWearTheFollowing(IEnumerable<IDressInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                instruction.Execute();
            }
        }

        [Then(@"I can leave house")]
        public void ThenICanLeaveHouse()
        {
            Assert.Contains("leaving house", dressed);
        }

        [Then(@"shirt I put on should be ""(.*)""")]
        public void ThenShirtIPutOnShouldBe(string shirtType)
        {
            Assert.Contains<string>(shirtType, dressed);
        }

        [Then(@"pants I put on should be ""(.*)""")]
        public void ThenPantsIPutOnShouldBe(string pantsType)
        {
            Assert.Contains<string>(pantsType, dressed);

        }

        [Then(@"headwear should be ""(.*)""")]
        public void ThenHeadwearShouldBe(string headwearType)
        {
            Assert.Contains<string>(headwearType, dressed);
        }

        [Then(@"footweear should be ""(.*)""")]
        public void ThenFootweearShouldBe(string footwearType)
        {
            Assert.Contains<string>(footwearType, dressed);
        }

        [Then(@"should put on Jacket")]
        public void ThenShouldPutOnJacket()
        {
            Assert.Contains<string>("jacket", dressed);
        }

        [Then(@"should put on Socks")]
        public void ThenShouldPutOnSocks()
        {
            Assert.Contains<string>("socks", dressed);
        }

        [Then(@"the dressing should fail")]
        public void ThenTheDressingShouldFail()
        {
            Assert.Contains("fail", dressed);
        }
    }
}
