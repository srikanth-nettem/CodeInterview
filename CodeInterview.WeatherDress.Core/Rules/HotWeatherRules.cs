using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

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

        protected override void ConfigureRulesForFootwearOn()
        {
            base.ConfigureRulesForFootwearOn();
            _rulesEngine.AddRule(Dress.FootwearOn, new KeyValuePair<Dress, bool>(Dress.SocksOn, false));
        }

        protected override void ConfigureRulesForLeaveHouse()
        {
            base.ConfigureRulesForLeaveHouse();
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.JacketOn, false));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.SocksOn, false));
        }

    }
}
