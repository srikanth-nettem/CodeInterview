using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.State
{
    public interface IStateManager
    {
        DressCommand CurrentState { get; set; }
        bool isStateVisited(DressCommand instruction);
    }
}
