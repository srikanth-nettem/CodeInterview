using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core
{
    public interface IWriter
    {
        void Write(string statement);

        void WriteLine(string statement);
    }
}
