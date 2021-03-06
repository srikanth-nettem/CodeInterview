﻿using Xunit;
using NSubstitute;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Tests.Instructions
{
    [Trait("Category", "unit")]
    public class HeadwearInstructionTests
    {
        private IDressInstruction _headwearInstruction;
        private readonly IWeatherDressing _weatherMock;
        private readonly IStateManager _stateManager;

        public HeadwearInstructionTests()
        {
            _stateManager = Substitute.For<IStateManager>();
            _weatherMock = Substitute.For<IWeatherDressing>();
            _headwearInstruction = new HeadwearInstruction(_weatherMock, _stateManager);
        }

        [Fact(DisplayName = "should call PutOnHeadwear on Weather instance on execution.")]
        public void onExecute()
        {
            _headwearInstruction.Execute();
            _weatherMock.Received().PutOnHeadwear();
            _stateManager.Received().CurrentState = Dress.HeadwearOn;
        }
    }
}