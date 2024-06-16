using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.Controllers;
using TrafficLightAssesment.Facade;
using UnityEngine;

namespace TrafficLightAssesment.StateMachine
{
    public class GreenLightFacadeState : BaseLightFacadeState
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Green facade");
            _trafficLightController.SetLightToGreenAndNotify();
            LightFacadeHelper.TurnToRed = true;
        }

        public GreenLightFacadeState(ITimer timer, TrafficLightController trafficLightController) : base(timer,
            trafficLightController)
        {
        }
    }

    public class AmberLightFacadeState : BaseLightFacadeState
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Amber facade");
            _trafficLightController.SetLightToAmberAndNotify();
        }

        public AmberLightFacadeState(ITimer timer, TrafficLightController trafficLightController) : base(timer,
            trafficLightController)
        {
        }
    }

    public class RedLightFacadeState : BaseLightFacadeState
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Red facade");
            _trafficLightController.SetLightToRedAndNotify();
            LightFacadeHelper.TurnToRed = false;
        }

        public RedLightFacadeState(ITimer timer, TrafficLightController trafficLightController) : base(timer,
            trafficLightController)
        {
        }
    }
}