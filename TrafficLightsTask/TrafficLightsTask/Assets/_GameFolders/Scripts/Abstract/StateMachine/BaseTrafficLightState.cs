using TrafficLightAssesment.Struct;

namespace TrafficLightAssesment.Abstract.StateMachine
{
    public abstract class BaseTrafficLightState : BaseState
    {
        protected LightStateStruct _lightStateStruct;

        public BaseTrafficLightState(LightStateStruct lightStateStruct)
        {
            _lightStateStruct = lightStateStruct;
        }
    }
}