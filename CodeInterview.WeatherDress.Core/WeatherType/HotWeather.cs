
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.Validations;
using System;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class HotWeather:IWeatherType
    {
        private readonly IWriter _writer;
        private readonly IDressValidator _dressValidator;
        public HotWeather(IWriter writer, IDressValidator dressValidator)
        {
            _writer = writer;
            _dressValidator = dressValidator;
        }

        private void validateDress(DressCommand dressCommand, Action callback)
        {
            if (!_dressValidator.isValid(dressCommand))
            {
                throw new NotSupportedDressException(String.Format("Validation rule failed for {0}", dressCommand));
            }

            callback();
        }

        public void PutOnShirt()
        {
            validateDress(DressCommand.ShirtOn, 
            ()=> _writer.Write("shirt") );
        }

        public void PutOnPants()
        {
            validateDress(DressCommand.PantsOn,
            ()=> _writer.Write("shorts") );
        }

        public void PutOnHeadwear()
        {
            validateDress(DressCommand.PantsOn,
            ()=>_writer.Write("sun visor"));
        }

        public void PutOnFootwear()
        {
            validateDress(DressCommand.PantsOn,
            ()=>_writer.Write("sandals"));
        }

        public void PutOnJacket()
        {
            validateDress(DressCommand.JacketOn,
            () => { throw new InvalidDressInstructionException("Cannot wear Jacket in Hot Weather"); });
        }

        public void PutOnSocks()
        {
            validateDress(DressCommand.SocksOn,
            () => { throw new InvalidDressInstructionException("Cannot wear Socks in Hot Weather"); });

        }

        public void TakeOffPajamas()
        {
            _writer.Write("Removing PJs");
        }

        public void LeaveHouse()
        {
            _writer.Write("leaving house");
        }
    }
}
