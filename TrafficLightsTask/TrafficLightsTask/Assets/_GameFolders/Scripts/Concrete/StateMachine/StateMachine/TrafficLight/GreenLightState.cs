using TrafficLightAssesment.Abstract.StateMachine;
using UnityEngine;

namespace TrafficLightAssesment.StateMachine
{
    public class GreenLightState : BaseTrafficLightState
    {
        public override void Enter()
        {
            Debug.Log("Green Light On");
        }
    }
    public class AmberLightState : BaseTrafficLightState
    {
        public override void Enter()
        {
            Debug.Log("Amber Light On");
        }
    }
    public class RedLightState : BaseTrafficLightState
    {
        override public void Enter()
        {
            Debug.Log("Red Light On");
        }
    }
}
