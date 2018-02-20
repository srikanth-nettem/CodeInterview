using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.State
{
    public interface IStateManager
    {
        Dress CurrentState { get; set; }
        bool isStateVisited(Dress instruction);
    }
}
