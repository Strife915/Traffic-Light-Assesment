using System;
using UnityEngine;
using TrafficLightAssesment.StateMachine;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.ScriptableObjects;
namespace TrafficLightAssesment.Controllers
{
    public class TrafficLightController : MonoBehaviour
    {
        [SerializeField] TrafficLightTimerSo _trafficLightTimerSo;
        StateMachine.StateMachine _stateMachine;
        IState _greenLightState;
        IState _amberLightState;
        IState _redLightState;
        void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
            _greenLightState = new GreenLightState(_trafficLightTimerSo);
            _amberLightState = new AmberLightState(_trafficLightTimerSo);
            _redLightState = new RedLightState(_trafficLightTimerSo);
        }
        void At(IState from, IState to, IPredicate condition) =>_stateMachine.AddTransition(from, to, condition);
        void Any(IState to,IPredicate condition) => _stateMachine.AddAnyTransition(to, condition);
    }
    
}
