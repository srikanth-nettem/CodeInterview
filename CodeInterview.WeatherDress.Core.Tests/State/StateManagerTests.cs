using Xunit;
using CodeInterview.WeatherDress.Core.State;

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
            _stateManager.CurrentState = DressCommand.FootwearOn;
            Assert.Equal(DressCommand.FootwearOn, _stateManager.CurrentState);
        }

        [Fact(DisplayName = "Previously setState should be the visitedState")]
        public void previousStateAsVisitedState()
        {
            //given
            _stateManager.CurrentState = DressCommand.SocksOn;

            //when
            _stateManager.CurrentState = DressCommand.HeadwearOn;
            Assert.True(_stateManager.isStateVisited(DressCommand.SocksOn));
        }

    }
}
