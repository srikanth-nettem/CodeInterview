using System.Collections.Generic;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.State
{
    public class StateManager : IStateManager
    {
        private Dress _currentState;

        private ISet<Dress> _visitedStates;

        private Dress _previousState=Dress.NULL;
        public StateManager()
        {
            _visitedStates = new HashSet<Dress>();
        }
        public Dress CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                _visitedStates.Add(_previousState);
                _previousState = value;
                _currentState = value;
            }
        }

        public bool isStateVisited(Dress instruction)
        {
            return _visitedStates.Contains(instruction);
        }
    }
}
