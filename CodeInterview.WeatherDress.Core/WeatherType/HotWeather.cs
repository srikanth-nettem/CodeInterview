
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.Validations;
using System;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class HotWeather:WeatherDressing
    {
        public HotWeather(IWriter writer, IDressValidator dressValidator) : base(writer, dressValidator)
        {
        }

        public override void PutOnShirt()
        {
            validateDress(DressCommand.ShirtOn, 
            ()=> _writer.Write("shirt") );
        }

        public override void PutOnPants()
        {
            validateDress(DressCommand.PantsOn,
            ()=> _writer.Write("shorts") );
        }

        public override void PutOnHeadwear()
        {
            validateDress(DressCommand.PantsOn,
            ()=>_writer.Write("sun visor"));
        }

        public override void PutOnFootwear()
        {
            validateDress(DressCommand.PantsOn,
            ()=>_writer.Write("sandals"));
        }

        public override void PutOnJacket()
        {
            validateDress(DressCommand.JacketOn,
            () => { throw new InvalidDressInstructionException("Cannot wear Jacket in Hot Weather"); });
        }

        public override void PutOnSocks()
        {
            validateDress(DressCommand.SocksOn,
            () => { throw new InvalidDressInstructionException("Cannot wear Socks in Hot Weather"); });

        }

        public override void LeaveHouse()
        {
            _writer.Write("leaving house");
        }
    }
}
