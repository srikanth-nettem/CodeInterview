using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeInterview.WeatherDress.Core.WeatherType;


namespace CodeInterview.WeatherDress.Core.Instructions
{
    public class ShirtInstruction : IInstruction
    {
        private IWeatherType _weatherType;
        public ShirtInstruction(IWeatherType weatherType)
        {
            _weatherType = weatherType;
        }
        public void Execute()
        {
            _weatherType.PutOnShirt();
        }
    }
}
