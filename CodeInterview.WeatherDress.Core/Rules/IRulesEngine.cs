using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public interface IRulesEngine
    {
        void ClearRules();
        void AddRule(Dress dressCommand, KeyValuePair<Dress, bool> rule);
        IDictionary<Dress, bool> GetRule(Dress dressCommand);
    }
}
