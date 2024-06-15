using TrafficLightAssesment.Abstract.Mediator;
using UnityEngine;
using TrafficLightAssesment.StateMachine;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Mediator;
using TrafficLightAssesment.ScriptableObjects;
namespace TrafficLightAssesment.Controllers
{
    public class TrafficLightController : MonoBehaviour
    {
        [SerializeField] TrafficLightTimerSo _trafficLightTimerSo;
        [SerializeField] TrafficLightMediator _trafficLightMediator;
        IMediator<TrafficLightController> _mediator => _trafficLightMediator;
        StateMachine.StateMachine _stateMachine;
        IState _greenLightState;
        IState _amberLightState;
        IState _redLightState;
        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _mediator.Register(this);
            _greenLightState = new GreenLightState(_trafficLightTimerSo);
            _amberLightState = new AmberLightState(_trafficLightTimerSo);
            _redLightState = new RedLightState(_trafficLightTimerSo);
        }
        void At(IState from, IState to, IPredicate condition) =>_stateMachine.AddTransition(from, to, condition);
        void Any(IState to,IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);
        
        public void SetLightToRed() => _stateMachine.SetState(_redLightState);
        public void SetLightToGreen() => _stateMachine.SetState(_greenLightState);
    }
    
}
