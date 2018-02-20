using Xunit;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.State
{
    [Trait("Category", "unit")]
    public class StateManagerTests
    {
        IStateManager _stateManager;

        public StateManagerTests()
        {
            _stateManager = new StateManager();
        }

        [Fact(DisplayName ="Should get the current set state")]
        public void ShouldGetTheCurrentState()
        {
            _stateManager.CurrentState = Dress.FootwearOn;
            Assert.Equal(Dress.FootwearOn, _stateManager.CurrentState);
        }

        [Fact(DisplayName = "Previously setState should be the visitedState")]
        public void previousStateAsVisitedState()
        {
            //given
            _stateManager.CurrentState = Dress.SocksOn;

            //when
            _stateManager.CurrentState = Dress.HeadwearOn;
            Assert.True(_stateManager.isStateVisited(Dress.SocksOn));
        }

    }
}
