using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.Weather;
using CodeInterview.WeatherDress.Core.State;

namespace Weather.Dress.Core.Tests.StepTransformations
{
    [Binding]
    public class StepTransformations
    {
       
        [StepArgumentTransformation]
        public IEnumerable<IDressInstruction> DressCode(Table dressTable)    
        {
            List<IDressInstruction> dresses = new List<IDressInstruction>();
            IEnumerable<dynamic> dressCommands = dressTable.CreateDynamicSet();

            foreach(var dressCommand in dressCommands)
            {
                CodeInterview.WeatherDress.Core.Utils.Dress dress;
                System.Enum.TryParse<CodeInterview.WeatherDress.Core.Utils.Dress>(dressCommand.DressCode, out dress);
                dresses.Add(InstantiateDress(dress));
            }
            return dresses;
        }

        private IDressInstruction InstantiateDress(CodeInterview.WeatherDress.Core.Utils.Dress dressCommand)
        {
            IStateManager stateManager = (IStateManager)ScenarioContext.Current["DressState"];
            WeatherDressing weatherTypeMock = (WeatherDressing)ScenarioContext.Current["WeatherType"];
            switch (dressCommand)
            {
                case CodeInterview.WeatherDress.Core.Utils.Dress.Pajamas_Off:
                    return new PajamasInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.ShirtOn:
                    return new ShirtInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.PantsOn:
                    return new PantsInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.JacketOn:
                    return new JacketInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.SocksOn:
                    return new SocksInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.HeadwearOn:
                    return new HeadwearInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.FootwearOn:
                    return new FootwearInstruction(weatherTypeMock, stateManager);
                case CodeInterview.WeatherDress.Core.Utils.Dress.LeaveHouse:
                    return new LeaveHouseInstruction(weatherTypeMock, stateManager);
                default:
                    throw new Exception("Invalid Command");
            }
        }
    }
}
