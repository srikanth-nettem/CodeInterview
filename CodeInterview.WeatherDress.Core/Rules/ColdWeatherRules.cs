﻿using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class ColdWeatherRules : IWeatherRules
    {
        private IRulesEngine _rulesEngine;

        public ColdWeatherRules(IRulesEngine rulesEngine)
        {
            _rulesEngine = rulesEngine;
        }

        public void ConfigureRules()
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

            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.HeadwearOn, false));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.FootwearOn, false));
            _rulesEngine.AddRule(DressCommand.ShirtOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, false));
            _rulesEngine.AddRule(DressCommand.PantsOn, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, false));
            _rulesEngine.AddRule(DressCommand.SocksOn, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, false));
            _rulesEngine.AddRule(DressCommand.JacketOn, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, false));
            _rulesEngine.AddRule(DressCommand.Pajamas_Off, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, false));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.LeaveHouse, false));

        }
    }
    }
