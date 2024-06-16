using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.Controllers;
using TrafficLightAssesment.Predicate;
using TrafficLightAssesment.ScriptableObjects;
using TrafficLightAssesment.StateMachine;
using TrafficLightAssesment.Timer;
using UnityEngine;

namespace TrafficLightAssesment.Facade
{
    public class LightFacade : MonoBehaviour
    {
        [SerializeField] TrafficLightController _initialGreen;
        [SerializeField] TrafficLightTimerSo _timerSo;
        StateMachine.StateMachine _stateMachine;
        IMediator<TrafficLightController> _mediator;
        ITimer _greenTimer;
        ITimer _amberTimer;
        ITimer _redTimer;
        IState _greenLightFacadeState;
        IState _amberLightFacadeState;
        IState _redLightFacadeState;

        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _mediator = GetComponent<IMediator<TrafficLightController>>();
            _greenTimer = new GreenLightTimer(_timerSo);
            _amberTimer = new AmberLightTimer(_timerSo);
            _redTimer = new RedLightTimer(_timerSo);
            _greenLightFacadeState = new GreenLightFacadeState(_greenTimer, _initialGreen);
            _amberLightFacadeState = new AmberLightFacadeState(_amberTimer, _initialGreen);
            _redLightFacadeState = new RedLightFacadeState(_redTimer, _initialGreen);

            // At(_greenLightFacadeState, _amberLightFacadeState, new FuncPredicate(() => _greenTimer.TimerFinished));
            // At(_amberLightFacadeState, _redLightFacadeState, new FuncPredicate((() => _amberTimer.TimerFinished)));
            // At(_redLightFacadeState, _amberLightFacadeState, new FuncPredicate((() => _amberTimer.TimerFinished)));
            // At(_amberLightFacadeState, _greenLightFacadeState, new FuncPredicate((() => _amberTimer.TimerFinished)));

            Any(_amberLightFacadeState,
                new FuncPredicate((() => _greenTimer.TimerFinished || _redTimer.TimerFinished)));
            Any(_redLightFacadeState,
                new FuncPredicate((() => _amberTimer.TimerFinished && LightFacadeHelper.TurnToRed)));
            Any(_greenLightFacadeState,
                new FuncPredicate((() => _amberTimer.TimerFinished && !LightFacadeHelper.TurnToRed)));
        }

        void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);

        void Start()
        {
            _stateMachine.SetState(_greenLightFacadeState);
        }

        void Update()
        {
            _stateMachine.Update();
        }
    }
}