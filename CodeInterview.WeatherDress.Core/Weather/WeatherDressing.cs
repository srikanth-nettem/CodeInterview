
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.io;
using CodeInterview.WeatherDress.Core.Validations;
using System;
using CodeInterview.WeatherDress.Core.Utils;

namespace CodeInterview.WeatherDress.Core.Weather
{
   public abstract class WeatherDressing:IWeatherDressing
    {

    protected readonly IWriter _writer;
    protected readonly IDressValidator _dressValidator;
    public WeatherDressing(IWriter writer, IDressValidator dressValidator)
    {
        _writer = writer;
        _dressValidator = dressValidator;
    }

    protected internal void validateDress(Dress dressCommand, Action callback)
    {
        if (!_dressValidator.isValid(dressCommand))
        {
            throw new WeatherDressRuleViolatedException(string.Format("Voilated the rule for {0}", dressCommand));
        }

        callback();
    }
    public abstract void PutOnShirt();
    public abstract void PutOnPants();
    public abstract void PutOnHeadwear();
    public abstract void PutOnFootwear();
    public abstract void PutOnJacket();
    public abstract void PutOnSocks();
    public void TakeOffPajamas()
        {
            validateDress(Dress.Pajamas_Off,
            () => _writer.Write(Constants.PAJAMAS_OFF));
        }
     public abstract void LeaveHouse();
       }
}
