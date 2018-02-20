using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class ColdWeatherRules : WeatherRules
    {

        public ColdWeatherRules(IRulesEngine rulesEngine):base(rulesEngine)
        {
        }

        public override void ConfigureRules()
        {
            ConfigureRulesForLeaveHouse();
            ConfigureRulesForShirtOn();
            ConfigureRulesForPantsOn();
            ConfigureRulesForSocksOn();
            ConfigureRulesForFootwearOn();
            ConfigureRulesForJacketOn();
            ConfigureRulesForHeadwearOn();
            ConfigureRulesForPajamasOff();
        }


        protected internal override void ConfigureRulesForFootwearOn()
        {
            base.ConfigureRulesForFootwearOn();
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, true));
        }

        protected internal override void ConfigureRulesForLeaveHouse()
        {
            base.ConfigureRulesForLeaveHouse();
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, true));
        }
    }
}
