using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.ScriptableObjects;

namespace TrafficLightAssesment.Timer
{
    public class GreenLightTimer : BaseTimer
    {
        public GreenLightTimer(TrafficLightTimerSo timerSo) : base(timerSo)
        {
            _maxTime = timerSo.GreenTime;
            SetTimer();
        }
    }

    public class AmberLightTimer : BaseTimer
    {
        public AmberLightTimer(TrafficLightTimerSo timerSo) : base(timerSo)
        {
            _maxTime = timerSo.YellowTime;
            SetTimer();
        }
    }

    public class RedLightTimer : BaseTimer
    {
        public RedLightTimer(TrafficLightTimerSo timerSo) : base(timerSo)
        {
            _maxTime = timerSo.RedTime;
            SetTimer();
        }
    }
}