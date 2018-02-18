using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.WeatherType
{
    public interface IWeatherDressing
    {
         void PutOnShirt();
         void PutOnPants();
         void PutOnHeadwear();
         void PutOnFootwear();
         void PutOnJacket();
         void PutOnSocks();
        void TakeOffPajamas();
         void LeaveHouse();

    }
}
