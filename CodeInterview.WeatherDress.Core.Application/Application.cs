using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.Weather;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeInterview.WeatherDress.Core.Application
{
    public static class Application
    {
        public static Container Container { get; private set; }
        public static void Bootstrap(string weatherType)
        {
            Container = new Container();

            Container.Configure(c =>
            {
                c.Scan(scanner =>
                {
                    scanner.Assembly("CodeInterview.WeatherDress.Core");
                    scanner.LookForRegistries();
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
                c.For<IWeatherDressing>().Use(weatherType);
            });

            Container.GetInstance<IWeatherRules>(weatherType).ConfigureRules();
        }
    }
}
