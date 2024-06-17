using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Abstract.Timer;
using TrafficLightAssesment.Controllers;
using TrafficLightAssesment.Predicate;
using TrafficLightAssesment.ScriptableObjects;
using TrafficLightAssesment.StateMachine;
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
        TimerFactory _timerFactory;
        
        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _mediator = GetComponent<IMediator<TrafficLightController>>();
            _timerFactory = new TimerFactory(_timerSo);
            _greenTimer = _timerFactory.CreateTimer("Green");
            _amberTimer = _timerFactory.CreateTimer("Amber");
            _redTimer = _timerFactory.CreateTimer("Red");
            _greenLightFacadeState = new GreenLightFacadeState(_greenTimer, _initialGreen);
            _amberLightFacadeState = new AmberLightFacadeState(_amberTimer, _initialGreen);
            _redLightFacadeState = new RedLightFacadeState(_redTimer, _initialGreen);

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