using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

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
            _rulesEngine.AddRule(Dress.FootwearOn, new KeyValuePair<Dress, bool>(Dress.SocksOn, true));
        }

        protected internal override void ConfigureRulesForLeaveHouse()
        {
            base.ConfigureRulesForLeaveHouse();
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.JacketOn, true));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.SocksOn, true));
        }
    }
}
