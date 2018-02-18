using Xunit;
using CodeInterview.WeatherDress.Core.Rules;

namespace CodeInterview.WeatherDress.Core.Tests.Rules
{
    [Trait("Category", "Component")]
    public class HotWeatherRulesTests
    {
        private IWeatherRules _weatherRules;
        private IRulesEngine _ruleEngine;

        public HotWeatherRulesTests()
        {
            _ruleEngine = new RulesEngine();
            _weatherRules = new HotWeatherRules(_ruleEngine);
            _weatherRules.ConfigureRules();
        }

        [Fact(DisplayName ="Should have Pajamas_Off before any DressCommand For HotWeather")]
        public void MandatoryPajamasOffRuleForAnyDressCommand()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.PantsOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.ShirtOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.FootwearOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.HeadwearOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.Pajamas_Off]);
        }

        [Fact(DisplayName = "Should have ShirtOn before Headwear in Hot Weather")]
        public void ShouldWearShirtBeforeHeadwear()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.HeadwearOn)[DressCommand.ShirtOn]);
        }

        [Fact(DisplayName = "Should have PantsOn before Footwear in Hot Weather")]
        public void ShouldWearPantsBeforeFootwear()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.FootwearOn)[DressCommand.PantsOn]);
        }

        [Fact(DisplayName = "Should have All DressOn before Leaving House For HotWeather")]
        public void AllDressOnForLeavingHouse()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.ShirtOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.FootwearOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.PantsOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.HeadwearOn]);
            Assert.False(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.JacketOn]);
            Assert.False(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.SocksOn]);
        }
    }
}
