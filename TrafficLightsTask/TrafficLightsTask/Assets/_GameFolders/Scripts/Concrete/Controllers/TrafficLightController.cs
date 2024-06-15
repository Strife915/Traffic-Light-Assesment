using TrafficLightAssesment.Abstract.Mediator;
using UnityEngine;
using TrafficLightAssesment.StateMachine;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.ScriptableObjects;

namespace TrafficLightAssesment.Controllers
{
    public class TrafficLightController : MonoBehaviour
    {
        StateMachine.StateMachine _stateMachine;
        IMediator<TrafficLightController> _mediator;
        IState _greenLightState;
        IState _amberLightState;
        IState _redLightState;

        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _mediator = GetComponentInParent<IMediator<TrafficLightController>>();
            _mediator.Register(this);
            _greenLightState = new GreenLightState();
            _amberLightState = new AmberLightState();
            _redLightState = new RedLightState();
        }

        void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

        public void SetLightToRed()
        {
            _stateMachine.SetState(_redLightState);
        }

        public void SetLightToGreen()
        {
            _stateMachine.SetState(_greenLightState);
            _mediator.Notify(this);
        }
    }
}