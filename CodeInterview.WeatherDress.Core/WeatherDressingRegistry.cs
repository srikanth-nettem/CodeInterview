using CodeInterview.WeatherDress.Core.Instructions;
using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Rules;
using CodeInterview.WeatherDress.Core.State;
using CodeInterview.WeatherDress.Core.Validations;
using CodeInterview.WeatherDress.Core.WeatherType;
using StructureMap;

namespace CodeInterview.WeatherDress.Core
{
    public class WeatherDressingRegistry : Registry
    {
        public WeatherDressingRegistry()
        {
            For<IWriter>().Use<ConsoleWriter>().Singleton();
            For<IStateManager>().Use<StateManager>().Singleton();
            For<IRulesEngine>().Use<RulesEngine>().Singleton();

            For<IWeatherRules>().Add<HotWeatherRules>()
                .Ctor<IRulesEngine>("rulesEngine").Is((config)=>config.GetInstance<IRulesEngine>())
                .Named("HOT");

            For<IWeatherRules>().Add<ColdWeatherRules>()
                .Ctor<IRulesEngine>("rulesEngine").Is((config)=>config.GetInstance<IRulesEngine>())
                .Named("COLD");

            For<IDressValidator>().Use<DressValidator>()
                .Ctor<IRulesEngine>("rulesEngine").Is((config)=>config.GetInstance<IRulesEngine>())
                .Ctor<IStateManager>("stateManager").Is((config)=>config.GetInstance<IStateManager>());

            For<IWeatherDressing>().Add<HotWeatherDressing>()
                .Ctor<IDressValidator>("dressValidator").Is((config) => config.GetInstance<IDressValidator>())
                .Ctor<IWriter>("writer").Is((config)=>config.GetInstance<IWriter>())
                .Named("HOT");

            For<IWeatherDressing>().Add<ColdWeatherDressing>()
                .Ctor<IDressValidator>("dressValidator").Is((config) => config.GetInstance<IDressValidator>())
                .Ctor<IWriter>("writer").Is((config) => config.GetInstance<IWriter>())
                .Named("COLD");

            For<IDressInstruction>().Add<PajamasInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is(
                (config) => 
                     config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config)=>config.GetInstance<IStateManager>())
                .Named("8");
                
            For<IDressInstruction>().Add<LeaveHouseInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("7");

            For<IDressInstruction>().Add<PantsInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("6");

            For<IDressInstruction>().Add<ShirtInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("4");

            For<IDressInstruction>().Add<SocksInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("3");

            For<IDressInstruction>().Add<HeadwearInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("2");

            For<IDressInstruction>().Add<FootwearInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("1");

            For<IDressInstruction>().Add<JacketInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("5");
        }
    }

}
