using Xunit;
using CodeInterview.WeatherDress.Core.Rules;

namespace CodeInterview.WeatherDress.Core.Tests.Rules
{
    [Trait("Category", "Component")]
    public class ColdWeatherRulesTests
    {
        private IWeatherRules _weatherRules;
        private IRulesEngine _ruleEngine;

        public ColdWeatherRulesTests()
        {
            _ruleEngine = new RulesEngine();
            _weatherRules = new ColdWeatherRules(_ruleEngine);
            _weatherRules.ConfigureRules();
        }

        [Fact(DisplayName = "Should have Pajamas_Off before any DressCommand For ColdWeather")]
        public void MandatoryPajamasOffRuleForAnyDressCommand()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.PantsOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.ShirtOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.FootwearOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.HeadwearOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.JacketOn)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.SocksOn)[DressCommand.Pajamas_Off]);
        }

        [Fact(DisplayName = "Should have ShirtOn before Headwear in Cold Weather")]
        public void ShouldWearShirtBeforeHeadwear()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.HeadwearOn)[DressCommand.ShirtOn]);
        }

        [Fact(DisplayName = "Should have ShirtOn before Jacket in Cold Weather")]
        public void ShouldWearShirtBeforeJacket()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.JacketOn)[DressCommand.ShirtOn]);
        }

        [Fact(DisplayName = "Should have PantsOn before Footwear in Cold Weather")]
        public void ShouldWearPantsBeforeFootwear()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.FootwearOn)[DressCommand.PantsOn]);
        }

        [Fact(DisplayName = "Should have SocksOn before Footwear in Cold Weather")]
        public void ShouldWearSocksBeforeFootwear()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.FootwearOn)[DressCommand.SocksOn]);
        }

        [Fact(DisplayName = "Should have All DressOn before Leaving House For Cold Weather")]
        public void AllDressOnForLeavingHouse()
        {
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.ShirtOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.FootwearOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.PantsOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.HeadwearOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.JacketOn]);
            Assert.True(_ruleEngine.GetRule(DressCommand.LeaveHouse)[DressCommand.SocksOn]);
        }
    }
}