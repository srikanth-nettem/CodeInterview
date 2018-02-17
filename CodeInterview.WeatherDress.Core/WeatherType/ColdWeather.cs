using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public class ColdWeather:IWeatherType
    {
        private readonly IWriter _writer;
        public ColdWeather(IWriter writer)
        {
            _writer = writer;
        }

        public void PutOnShirt()
        {
            _writer.Write("t-shirt");
        }

        public void PutOnPants()
        {
            _writer.Write("pants");
        }

        public void PutOnHeadwear()
        {
            _writer.Write("hat");
        }

        public void PutOnFootwear()
        {
            _writer.Write("boots");
        }

        public void PutOnJacket()
        {
            _writer.Write("jacket");
        }

        public void PutOnSocks()
        {
            _writer.Write("socks");
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
