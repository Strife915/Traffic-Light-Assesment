using TrafficLightAssesment.ScriptableObjects;

namespace TrafficLightAssesment.Abstract.StateMachine
{
    public abstract class BaseState : IState
    {
        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }

    public class BaseTrafficLightState : BaseState
    {
        TrafficLightTimerSo _trafficLightTimerSo;

        public BaseTrafficLightState(TrafficLightTimerSo trafficLightTimerSo)
        {
            _trafficLightTimerSo = trafficLightTimerSo;
        }
    }
}