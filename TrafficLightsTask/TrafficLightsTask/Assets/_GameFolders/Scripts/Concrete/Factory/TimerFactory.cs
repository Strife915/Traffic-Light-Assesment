using System;
using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.ScriptableObjects;
using TrafficLightAssesment.Timer;

public class TimerFactory
{
     TrafficLightTimerSo _timerSo;

    public TimerFactory(TrafficLightTimerSo timerSo)
    {
        _timerSo = timerSo;
    }

    public ITimer CreateTimer(string timerType)
    {
        switch (timerType)
        {
            case "Green":
                return new GreenLightTimer(_timerSo);
            case "Amber":
                return new AmberLightTimer(_timerSo);
            case "Red":
                return new RedLightTimer(_timerSo);
            default:
                throw new ArgumentException("Invalid timer type", nameof(timerType));
        }
    }
}