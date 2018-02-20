using NSubstitute;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core;
using CodeInterview.WeatherDress.Core.State;

namespace Weather.Dress.Core.Tests.StepTransformations
{
   [Binding]
    public class StepTransformations
    {
       
        [StepArgumentTransformation]
        public IEnumerable<IDressInstruction> Dress(Table dressTable)    
        {
            List<IDressInstruction> dresses = new List<IDressInstruction>();
            IEnumerable<dynamic> dressCommands = dressTable.CreateDynamicSet();

            foreach(var dressCommand in dressCommands)
            {
                DressCommand dress;
                Enum.TryParse<DressCommand>(dressCommand.Dress, out dress);
                dresses.Add(InstantiateDress(dress));
            }
            return dresses;
        }

        private IDressInstruction InstantiateDress(DressCommand dressCommand)
        {
            IStateManager stateManager = (IStateManager)ScenarioContext.Current["DressState"];
            WeatherDressing weatherTypeMock = (WeatherDressing)ScenarioContext.Current["WeatherType"];
            switch (dressCommand)
            {
                case DressCommand.Pajamas_Off:
                    return new PajamasInstruction(weatherTypeMock, stateManager);
                case DressCommand.ShirtOn:
                    return new ShirtInstruction(weatherTypeMock, stateManager);
                case DressCommand.PantsOn:
                    return new PantsInstruction(weatherTypeMock, stateManager);
                case DressCommand.JacketOn:
                    return new JacketInstruction(weatherTypeMock, stateManager);
                case DressCommand.SocksOn:
                    return new SocksInstruction(weatherTypeMock, stateManager);
                case DressCommand.HeadwearOn:
                    return new HeadwearInstruction(weatherTypeMock, stateManager);
                case DressCommand.FootwearOn:
                    return new FootwearInstruction(weatherTypeMock, stateManager);
                case DressCommand.LeaveHouse:
                    return new LeaveHouseInstruction(weatherTypeMock, stateManager);
                default:
                    throw new Exception("Invalid Command");
            }
        }
    }
}
