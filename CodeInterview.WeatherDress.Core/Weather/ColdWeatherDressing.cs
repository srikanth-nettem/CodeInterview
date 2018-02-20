using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Weather
{
    public class ColdWeatherDressing:WeatherDressing
    {
        public ColdWeatherDressing(IWriter writer, IDressValidator dressValidator) : base(writer, dressValidator)
        {
        }

        public override void PutOnShirt()
        {
            validateDress(Dress.ShirtOn,
            () => _writer.Write(Constants.SHIRT));
        }

        public override void PutOnPants()
        {
            validateDress(Dress.PantsOn,
            () => _writer.Write(Constants.PANTS));
        }

        public override void PutOnHeadwear()
        {
            validateDress(Dress.HeadwearOn,
            () => _writer.Write(Constants.HAT));
        }

        public override void PutOnFootwear()
        {
            validateDress(Dress.FootwearOn,
            () => _writer.Write(Constants.BOOTS));
        }

        public override void PutOnJacket()
        {
            validateDress(Dress.JacketOn,
            () => _writer.Write(Constants.JACKET));
        }

        public override void PutOnSocks()
        {
            validateDress(Dress.SocksOn,
            () => _writer.Write(Constants.SOCKS));
        }

        public override void LeaveHouse()
        {
            validateDress(Dress.LeaveHouse,
            () => _writer.Write(Constants.LEAVING_HOME));
        }
    }
}
