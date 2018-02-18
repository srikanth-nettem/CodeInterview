using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeInterview.WeatherDress.Core.Validations;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class ColdWeather:WeatherDressing
    {
        public ColdWeather(IWriter writer, IDressValidator dressValidator) : base(writer, dressValidator)
        {
        }

        public override void PutOnShirt()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("t-shirt"));
        }

        public override void PutOnPants()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("pants"));
        }

        public override void PutOnHeadwear()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("hat"));
        }

        public override void PutOnFootwear()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("boots"));
        }

        public override void PutOnJacket()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("jacket"));
        }

        public override void PutOnSocks()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("socks"));
        }

        public override void LeaveHouse()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("leaving house"));
        }
    }
}
