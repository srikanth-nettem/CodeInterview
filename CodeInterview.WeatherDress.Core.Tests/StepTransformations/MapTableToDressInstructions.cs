using NSubstitute;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.WeatherType;
using CodeInterview.WeatherDress.Core;

namespace Weather.Dress.Core.Tests.StepTransformations
{
   [Binding]
    public class StepTransformations
    {
        [StepArgumentTransformation]
        public IEnumerable<IInstruction> Dress(Table dressTable)    
        {
            List<IInstruction> dresses = new List<IInstruction>();
            IEnumerable<dynamic> dressCommands = dressTable.CreateDynamicSet();

            foreach(var dressCommand in dressCommands)
            {
                DressCommand dress;
                Enum.TryParse<DressCommand>(dressCommand.Dress, out dress);
                dresses.Add(InstantiateDress(dress));
            }
            return dresses;
        }

        private IInstruction InstantiateDress(DressCommand dressCommand)
        {
             IWeatherType weatherTypeMock = (IWeatherType)ScenarioContext.Current["WeatherType"];
            switch (dressCommand)
            {
                case DressCommand.Pajamas_Off:
                    return new PajamasInstruction(weatherTypeMock);
                case DressCommand.ShirtOn:
                    return new ShirtInstruction(weatherTypeMock);
                case DressCommand.PantsOn:
                    return new PantsInstruction(weatherTypeMock);
                case DressCommand.JacketOn:
                    return new JacketInstruction(weatherTypeMock);
                case DressCommand.SocksOn:
                    return new SocksInstruction(weatherTypeMock);
                case DressCommand.HeadwearOn:
                    return new HeadwearInstruction(weatherTypeMock);
                case DressCommand.FootwearOn:
                    return new FootwearInstruction(weatherTypeMock);
                default:
                    throw new Exception("Invalid Command");
            }
        }
    }
}
