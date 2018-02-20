using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public class RulesEngine : IRulesEngine
    {
        IDictionary<Dress, IDictionary<Dress, bool>> rules;

        public RulesEngine()
        {
            rules = new Dictionary<Dress, IDictionary<Dress, bool>>();
        }
        public void AddRule(Dress dressCommand, KeyValuePair<Dress, bool> ruleSet)
        {
            if (!rules.Keys.Contains(dressCommand))
            {
                IDictionary<Dress, bool> rule = new Dictionary<Dress, bool>();
                rules.Add(dressCommand, rule);
            }
            rules[dressCommand].Add(ruleSet);
        }

        public void ClearRules()
        {
            rules.Clear();
        }

        public IDictionary<Dress, bool> GetRule(Dress dressCommand)
        {
            return rules[dressCommand];
        }
    }
}
