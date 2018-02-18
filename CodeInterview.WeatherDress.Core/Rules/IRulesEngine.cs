using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.Rules
{
    public interface IRulesEngine
    {
         void AddRule(DressCommand dressCommand, KeyValuePair<DressCommand, bool> rule);
        IDictionary<DressCommand, bool> GetRule(DressCommand dressCommand);
    }
}
