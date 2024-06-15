using System;
using TrafficLightAssesment.Abstract.StateMachine;
using UnityEngine;

namespace TrafficLightAssesment.Predicate 
{
    public class FuncPredicate : IPredicate
    {
        readonly Func<bool> _func;

        public FuncPredicate(Func<bool> func)
        {
            _func = func;
        }

        public bool Evaluate() => _func.Invoke();
    }
    
}
