using Xunit;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.Utils;

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
            Assert.True(_ruleEngine.GetRule(Dress.PantsOn)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.ShirtOn)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.FootwearOn)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.HeadwearOn)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.JacketOn)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.SocksOn)[Dress.Pajamas_Off]);
        }

        [Fact(DisplayName = "Should have ShirtOn before Headwear in Cold Weather")]
        public void ShouldWearShirtBeforeHeadwear()
        {
            Assert.True(_ruleEngine.GetRule(Dress.HeadwearOn)[Dress.ShirtOn]);
        }

        [Fact(DisplayName = "Should have ShirtOn before Jacket in Cold Weather")]
        public void ShouldWearShirtBeforeJacket()
        {
            Assert.True(_ruleEngine.GetRule(Dress.JacketOn)[Dress.ShirtOn]);
        }

        [Fact(DisplayName = "Should have PantsOn before Footwear in Cold Weather")]
        public void ShouldWearPantsBeforeFootwear()
        {
            Assert.True(_ruleEngine.GetRule(Dress.FootwearOn)[Dress.PantsOn]);
        }

        [Fact(DisplayName = "Should have SocksOn before Footwear in Cold Weather")]
        public void ShouldWearSocksBeforeFootwear()
        {
            Assert.True(_ruleEngine.GetRule(Dress.FootwearOn)[Dress.SocksOn]);
        }

        [Fact(DisplayName = "Should have All DressOn before Leaving House For Cold Weather")]
        public void AllDressOnForLeavingHouse()
        {
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.Pajamas_Off]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.ShirtOn]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.FootwearOn]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.PantsOn]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.HeadwearOn]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.JacketOn]);
            Assert.True(_ruleEngine.GetRule(Dress.LeaveHouse)[Dress.SocksOn]);
        }
    }
}