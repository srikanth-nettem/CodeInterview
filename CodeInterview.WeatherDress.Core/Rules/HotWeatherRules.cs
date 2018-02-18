using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class HotWeatherRules: IWeatherRules
    {
        private IRulesEngine _rulesEngine;
        public HotWeatherRules(IRulesEngine rulesEngine)
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
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.JacketOn, false));
            _rulesEngine.AddRule(DressCommand.LeaveHouse, new KeyValuePair<DressCommand, bool>(DressCommand.SocksOn, false));

            _rulesEngine.AddRule(DressCommand.ShirtOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));

            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.HeadwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.ShirtOn, true));

            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
            _rulesEngine.AddRule(DressCommand.FootwearOn, new KeyValuePair<DressCommand, bool>(DressCommand.PantsOn, true));

            _rulesEngine.AddRule(DressCommand.PantsOn, new KeyValuePair<DressCommand, bool>(DressCommand.Pajamas_Off, true));
        }
    }
}
