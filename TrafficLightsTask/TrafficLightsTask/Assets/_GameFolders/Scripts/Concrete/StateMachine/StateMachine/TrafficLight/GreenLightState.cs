using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Struct;
using UnityEngine;

namespace TrafficLightAssesment.StateMachine
{
    public class GreenLightState : BaseTrafficLightState
    {
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
        
        public RedLightState(LightStateStruct lightStateStruct) : base(lightStateStruct)
        {
        }

        public override void Exit()
        {
            _lightStateStruct.IsRed = false;
        }
    }
}