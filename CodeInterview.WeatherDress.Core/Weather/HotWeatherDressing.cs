
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Weather
{
    public class HotWeatherDressing:WeatherDressing
    {
        public HotWeatherDressing(IWriter writer, IDressValidator dressValidator) : base(writer, dressValidator)
        {
        }

        public override void PutOnShirt()
        {
            validateDress(Dress.ShirtOn, 
            ()=> _writer.Write(Constants.TSHIRT) );
        }

        public override void PutOnPants()
        {
            validateDress(Dress.PantsOn,
            ()=> _writer.Write(Constants.SHORTS) );
        }

        public override void PutOnHeadwear()
        {
            validateDress(Dress.HeadwearOn,
            ()=>_writer.Write(Constants.SUN_VISOR));
        }

        public override void PutOnFootwear()
        {
            validateDress(Dress.FootwearOn,
            ()=>_writer.Write(Constants.SANDALS));
        }

        public override void PutOnJacket()
        {
            throw new NotSupportedDressException("Cannot wear Jacket in Hot Weather");
        }

        public override void PutOnSocks()
        {
            throw new NotSupportedDressException("Cannot wear Socks in Hot Weather");
        }

        public override void LeaveHouse()
        {
            validateDress(Dress.LeaveHouse,
            () => _writer.Write(Constants.LEAVING_HOME));
        }
    }
}