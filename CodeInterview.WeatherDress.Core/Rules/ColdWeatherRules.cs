using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class ColdWeatherRules : IWeatherRules
    {
        private IRulesEngine _rulesEngine;

        public ColdWeatherRules(IRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }

        public void configureRules()
        {
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.HeadwearOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.FootwearOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, true));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, true));

            _rulesEngine.AddRule(DressCommand.ShirtOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.PantsOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.SocksOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));

            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, true));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, true));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));

            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));

            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));
        }
    }
    }
