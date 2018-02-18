using System.Collections.Generic;

namespace CodeInterview.WeatherDress.Core.State
{
    public class StateManager : IStateManager
    {
        private DressCommand _currentState;

        private ISet<DressCommand> _visitedStates;

        public StateManager()
        {
            _visitedStates = new HashSet<DressCommand>();
        }
        public DressCommand CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                _visitedStates.Add(value);
                _currentState = value;
            }
        }

        public bool isStateVisited(DressCommand instruction)
        {
            return _visitedStates.Contains(instruction);
        }
    }
}
