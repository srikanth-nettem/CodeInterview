
using CodeInterview.WeatherDress.Core.Exceptions;
using CodeInterview.WeatherDress.Core.Validations;
using System;

namespace CodeInterview.WeatherDress.Core.WeatherType
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

    protected internal void validateDress(DressCommand dressCommand, Action callback)
    {
        if (!_dressValidator.isValid(dressCommand))
        {
            throw new WeatherDressRuleViolatedException(string.Format("Validation rule failed for {0}", dressCommand));
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
            _writer.Write("Removing PJs");
        }
     public abstract void LeaveHouse();
       }
}
