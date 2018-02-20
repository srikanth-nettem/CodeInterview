using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public abstract class WeatherRules : IWeatherRules
    {
        protected internal readonly IRulesEngine _rulesEngine;

        public WeatherRules(IRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }
        public abstract void ConfigureRules();

        protected internal virtual void ConfigureRulesForPajamasOff()
        {
            _rulesEngine.AddRule(DressCommand.Pajamas_Off, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, false));
        }

        protected internal virtual void ConfigureRulesForPantsOn()
        {
            _rulesEngine.AddRule(DressCommand.PantsOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.PantsOn, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, false));
        }

        protected internal virtual void ConfigureRulesForFootwearOn()
        {
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, true));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.FootwearOn, false));
        }

        protected internal virtual void ConfigureRulesForSocksOn()
        {
            _rulesEngine.AddRule(DressCommand.SocksOn, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, false));
            _rulesEngine.AddRule(DressCommand.SocksOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
        }


        protected internal virtual void ConfigureRulesForJacketOn()
        {
            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, false));
            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));
        }

        protected internal virtual void ConfigureRulesForHeadwearOn()
        {
            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));
            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.HeadwearOn, false));
        }

        protected internal virtual void ConfigureRulesForShirtOn()
        {
            _rulesEngine.AddRule(DressCommand.ShirtOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.ShirtOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, false));
        }

        protected internal virtual void ConfigureRulesForLeaveHouse()
        {
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.LeaveHouse, false));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.HeadwearOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.FootwearOn, true));
        }

    }
}
