using UnityEngine;

namespace TrafficLightAssesment.Abstract.StateMachine
{
    public interface ITransition
    {
        IState TargetState { get; }
        IPredicate Condition { get; }
    }
    
}
