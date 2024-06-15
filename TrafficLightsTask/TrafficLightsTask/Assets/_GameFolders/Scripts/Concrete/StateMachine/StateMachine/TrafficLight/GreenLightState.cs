using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.ScriptableObjects;

namespace TrafficLightAssesment.StateMachine
{
    public class GreenLightState : BaseTrafficLightState
    {
        public GreenLightState(TrafficLightTimerSo trafficLightTimerSo) : base(trafficLightTimerSo)
        {
        }
    }
    public class AmberLightState : BaseTrafficLightState
    {
        public AmberLightState(TrafficLightTimerSo trafficLightTimerSo) : base(trafficLightTimerSo)
        {
        }
    }
    public class RedLightState : BaseTrafficLightState
    {
        public RedLightState(TrafficLightTimerSo trafficLightTimerSo) : base(trafficLightTimerSo)
        {
        }
    }
}
