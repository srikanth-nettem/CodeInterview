using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeInterview.WeatherDress.Core.Validations;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class ColdWeatherDressing:WeatherDressing
    {
        public ColdWeatherDressing(IWriter writer, IDressValidator dressValidator) : base(writer, dressValidator)
        {
        }

        public override void PutOnShirt()
        {
            validateDress(DressCommand.ShirtOn,
            () => _writer.Write("t-shirt"));
        }

        public override void PutOnPants()
        {
            validateDress(DressCommand.PantsOn,
            () => _writer.Write("pants"));
        }

        public override void PutOnHeadwear()
        {
            validateDress(DressCommand.HeadwearOn,
            () => _writer.Write("hat"));
        }

        public override void PutOnFootwear()
        {
            validateDress(DressCommand.FootwearOn,
            () => _writer.Write("boots"));
        }

        public override void PutOnJacket()
        {
            validateDress(DressCommand.JacketOn,
            () => _writer.Write("jacket"));
        }

        public override void PutOnSocks()
        {
            validateDress(DressCommand.SocksOn,
            () => _writer.Write("socks"));
        }

        public override void LeaveHouse()
        {
            validateDress(DressCommand.LeaveHouse,
            () => _writer.Write("leaving house"));
        }
    }
}
