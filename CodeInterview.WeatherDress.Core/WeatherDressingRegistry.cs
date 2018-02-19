using CodeInterview.WeatherDress.Core.Instructions;
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

            For<IInstruction>().Add<PajamasInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is(
                (config) => 
                     config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config)=>config.GetInstance<IStateManager>())
                .Named("8");
                
            For<IInstruction>().Add<LeaveHouseInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("7");

            For<IInstruction>().Add<PantsInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("6");

            For<IInstruction>().Add<ShirtInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("4");

            For<IInstruction>().Add<SocksInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("3");

            For<IInstruction>().Add<HeadwearInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("2");

            For<IInstruction>().Add<FootwearInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("1");

            For<IInstruction>().Add<JacketInstruction>()
                .Ctor<IWeatherDressing>("weatherType").Is((config) => config.GetInstance<IWeatherDressing>())
                .Ctor<IStateManager>("stateManager").Is((config) => config.GetInstance<IStateManager>())
                .Named("5");
        }
    }

}
