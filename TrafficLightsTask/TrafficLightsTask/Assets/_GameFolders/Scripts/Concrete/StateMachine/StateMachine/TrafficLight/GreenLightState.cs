using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Struct;
using UnityEngine;

namespace TrafficLightAssesment.StateMachine
{
    public class GreenLightState : BaseTrafficLightState
    {
        public override void Enter()
        {
            //Debug.Log("Green Light On");
        }

        public GreenLightState(LightStateStruct lightStateStruct) : base(lightStateStruct)
        {
        }

        public override void Exit()
        {
            _lightStateStruct.IsGreen = false;
        }
    }

    public class AmberLightState : BaseTrafficLightState
    {
        public override void Enter()
        {
            //Debug.Log("Amber Light On");
        }

        public AmberLightState(LightStateStruct lightStateStruct) : base(lightStateStruct)
        {
        }

        public override void Exit()
        {
            _lightStateStruct.IsAmber = false;
        }
    }

    public class RedLightState : BaseTrafficLightState
    {
        override public void Enter()
        {
            //Debug.Log("Red Light On");
        }

        public RedLightState(LightStateStruct lightStateStruct) : base(lightStateStruct)
        {
        }

        public override void Exit()
        {
            _lightStateStruct.IsRed = false;
        }
    }
}