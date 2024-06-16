using System;
using TrafficLightAssesment.Abstract.Mediator;
using UnityEngine;
using TrafficLightAssesment.StateMachine;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Predicate;
using TrafficLightAssesment.Struct;


namespace TrafficLightAssesment.Controllers
{
    public class TrafficLightController : MonoBehaviour
    {
        StateMachine.StateMachine _stateMachine;
        IMediator<TrafficLightController> _mediator;
        IState _greenLightState;
        IState _amberLightState;
        IState _redLightState;
        public LightStateStruct LightStateStruct = new LightStateStruct();

        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _mediator = GetComponentInParent<IMediator<TrafficLightController>>();
            _mediator.Register(this);
            _greenLightState = new GreenLightState(LightStateStruct);
            _amberLightState = new AmberLightState(LightStateStruct);
            _redLightState = new RedLightState(LightStateStruct);
            Any(_greenLightState, new FuncPredicate((() => LightStateStruct.IsGreen)));
            Any(_redLightState, new FuncPredicate((() => LightStateStruct.IsRed)));
            Any(_amberLightState, new FuncPredicate((() => LightStateStruct.IsAmber)));
            _stateMachine.SetState(_greenLightState);
        }

        void Update()
        {
            _stateMachine.Update();
        }

        void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

        public void SetLightToGreenAndNotify()
        {
            LightStateStruct.IsGreen = true;
            LightStateStruct.IsAmber = false;
            LightStateStruct.IsRed = false;
            _mediator.Notify(this);
        }

        public void SetLightToAmberAndNotify()
        {
            LightStateStruct.IsAmber = true;
            LightStateStruct.IsGreen = false;
            LightStateStruct.IsRed = false;
            _mediator.Notify(this);
        }

        public void SetLightToRedAndNotify()
        {
            LightStateStruct.IsRed = true;
            LightStateStruct.IsGreen = false;
            LightStateStruct.IsAmber = false;
            _mediator.Notify(this);
        }
    }
}