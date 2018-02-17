
namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class HotWeather:IWeatherType
    {
        private IWriter _writer;
        public HotWeather(IWriter writer)
        {
            _writer = writer;
        }

        public void PutOnShirt()
        {
            _writer.Write("shirt");
        }

        public void PutOnPants()
        {
            _writer.Write("shorts");
        }

        public void PutOnHeadwear()
        {
            _writer.Write("sun visor");
        }

        public void PutOnFootwear()
        {
            _writer.Write("sandals");
        }

        public void PutOnJacket()
        {
            _writer.Write("fail");
        }

        public void PutOnSocks()
        {
            _writer.Write("fail");
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
