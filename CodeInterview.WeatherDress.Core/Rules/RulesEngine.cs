using System;
using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class RulesEngine : IRulesEngine
    {
        IDictionary<DressCommand, IDictionary<DressCommand, bool>> rules;

        public RulesEngine()
        {
            rules = new Dictionary<DressCommand, IDictionary<DressCommand, bool>>();
        }
        public void AddRule(DressCommand dressCommand, KeyValuePair<DressCommand, bool> ruleSet)
        {
            if (!rules.Keys.Contains(dressCommand))
            {
                IDictionary<DressCommand, bool> rule = new Dictionary<DressCommand, bool>();
                rules.Add(dressCommand, rule);
            }
            rules[dressCommand].Add(ruleSet);
        }

        public void ClearRules()
        {
            rules.Clear();
        }

        public IDictionary<DressCommand, bool> GetRule(DressCommand dressCommand)
        {
            return rules[dressCommand];
        }
    }
}
