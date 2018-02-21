using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public abstract class WeatherRules : IWeatherRules
    {
        protected readonly IRulesEngine _rulesEngine;

        public WeatherRules(IRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }
        public abstract void ConfigureRules();

        protected virtual void ConfigureRulesForPajamasOff()
        {
            _rulesEngine.AddRule(Dress.Pajamas_Off, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, false));
        }

        protected virtual void ConfigureRulesForPantsOn()
        {
            _rulesEngine.AddRule(Dress.PantsOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.PantsOn, new KeyValuePair<Dress, bool>(Dress.PantsOn, false));
        }

        protected virtual void ConfigureRulesForFootwearOn()
        {
            _rulesEngine.AddRule(Dress.FootwearOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.FootwearOn, new KeyValuePair<Dress, bool>(Dress.PantsOn, true));
            _rulesEngine.AddRule(Dress.FootwearOn, new KeyValuePair<Dress, bool>(Dress.FootwearOn, false));
        }

        protected virtual void ConfigureRulesForSocksOn()
        {
            _rulesEngine.AddRule(Dress.SocksOn, new KeyValuePair<Dress, bool>(Dress.SocksOn, false));
            _rulesEngine.AddRule(Dress.SocksOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
        }


        protected virtual void ConfigureRulesForJacketOn()
        {
            _rulesEngine.AddRule(Dress.JacketOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.JacketOn, new KeyValuePair<Dress, bool>(Dress.JacketOn, false));
            _rulesEngine.AddRule(Dress.JacketOn, new KeyValuePair<Dress, bool>(Dress.ShirtOn, true));
        }

        protected virtual void ConfigureRulesForHeadwearOn()
        {
            _rulesEngine.AddRule(Dress.HeadwearOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.HeadwearOn, new KeyValuePair<Dress, bool>(Dress.ShirtOn, true));
            _rulesEngine.AddRule(Dress.HeadwearOn, new KeyValuePair<Dress, bool>(Dress.HeadwearOn, false));
        }

        protected virtual void ConfigureRulesForShirtOn()
        {
            _rulesEngine.AddRule(Dress.ShirtOn, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.ShirtOn, new KeyValuePair<Dress, bool>(Dress.ShirtOn, false));
        }

        protected virtual void ConfigureRulesForLeaveHouse()
        {
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.LeaveHouse, false));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.Pajamas_Off, true));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.PantsOn, true));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.ShirtOn, true));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.HeadwearOn, true));
            _rulesEngine.AddRule(Dress.LeaveHouse, new KeyValuePair<Dress, bool>(Dress.FootwearOn, true));
        }

    }
}
