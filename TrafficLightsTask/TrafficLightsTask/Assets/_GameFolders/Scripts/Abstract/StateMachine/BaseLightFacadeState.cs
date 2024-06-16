using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.Controllers;

namespace TrafficLightAssesment.Abstract.StateMachine
{
    public abstract class BaseLightFacadeState : BaseState
    {
        ITimer _timer;
        protected TrafficLightController _trafficLightController;

        public BaseLightFacadeState(ITimer timer, TrafficLightController trafficLightController)
        {
            _timer = timer;
            _trafficLightController = trafficLightController;
        }

        public override void Enter()
        {
            _timer.StartTimer();
        }

        public override void Exit()
        {
            _timer.ResetTimer();
        }

        public override void Update()
        {
            if (_timer == null) return;
            _timer.CountDown();
        }
    }
}