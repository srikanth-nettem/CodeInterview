using CodeInterview.WeatherDress.Core.Utils;
using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Validations
{
    public class DressValidator : IDressValidator
    {
        private IRulesEngine _rulesEngine;
        private IStateManager _stateManager;
        public DressValidator(IRulesEngine rulesEngine, IStateManager stateManager)
        {
            _rulesEngine = rulesEngine;
            _stateManager = stateManager;
        }

        public bool isValid(Dress dressCommand)
        {
            IDictionary<Dress, bool> rules = _rulesEngine.GetRule(dressCommand);
            bool flag = true;

            foreach(var rule in rules)
            {
                if (rule.Value)
                {
                    flag = flag && _stateManager.isStateVisited(rule.Key);
                }else
                {
                    flag = flag && !_stateManager.isStateVisited(rule.Key);
                }
            }
            return flag;
        }
    }
}
