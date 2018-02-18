﻿using System;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core.State;

namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class PajamasInstruction : IInstruction
    {
        private readonly IWeatherType _weatherType;
        private readonly IStateManager _stateManager;

        public PajamasInstruction(IWeatherType weatherType, IStateManager stateManager)
        {
            _weatherType = weatherType;
            _stateManager = stateManager;
        }

        public void Execute()
        {
            _stateManager.CurrentState = DressCommand.Pajamas_Off;
            _weatherType.TakeOffPajamas();
        }
    }
}