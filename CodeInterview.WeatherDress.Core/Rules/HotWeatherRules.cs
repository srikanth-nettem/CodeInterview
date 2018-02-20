using System;
using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class HotWeatherRules: WeatherRules
    {
        public HotWeatherRules(IRulesEngine rulesEngine) : base(rulesEngine) { }

        public override void ConfigureRules()
        {
            ConfigureRulesForLeaveHouse();
            ConfigureRulesForShirtOn();
            ConfigureRulesForHeadwearOn();
            ConfigureRulesForFootwearOn();
            ConfigureRulesForPantsOn();
            ConfigureRulesForPajamasOff();
        }

        protected internal override void ConfigureRulesForFootwearOn()
        {
            base.ConfigureRulesForFootwearOn();
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, false));
        }

        protected internal override void ConfigureRulesForLeaveHouse()
        {
            base.ConfigureRulesForLeaveHouse();
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, false));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, false));
        }

    }
}
