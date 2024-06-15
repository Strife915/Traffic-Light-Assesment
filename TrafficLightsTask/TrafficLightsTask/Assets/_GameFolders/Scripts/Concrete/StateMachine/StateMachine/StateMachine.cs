using System;
using System.Collections.Generic;
using TrafficLightAssesment.Abstract.StateMachine;

namespace TrafficLightAssesment.StateMachine
{
    public class StateMachine
    {
        StateNode current;
        Dictionary<Type, StateNode> _nodes = new Dictionary<Type, StateNode>();
        HashSet<ITransition> _anyTransitions = new HashSet<ITransition>();

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
                ChangeState(transition.TargetState);
            current.State?.Update();
        }

        public void SetState(IState state)
        {
            if (current == null) return;
            current = _nodes[state.GetType()];
            current.State?.Enter();
        }

        void ChangeState(IState state)
        {
            if (state == current.State) return;
            var prevState = current.State;
            var nextState = _nodes[state.GetType()].State;

            prevState?.Exit();
            nextState?.Enter();
            current = _nodes[state.GetType()];
        }

        ITransition GetTransition()
        {
            foreach (var transition in _anyTransitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            foreach (var transition in current.Transitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            return null;
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition(IState to, IPredicate condition)
        {
            _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
        }

        StateNode GetOrAddNode(IState state)
        {
            var node = _nodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                _nodes.Add(state.GetType(), node);
            }

            return node;
        }

        class StateNode
        {
            public IState State { get; private set; }
            public HashSet<ITransition> Transitions { get; private set; }

            public StateNode(IState state)
            {
                State = state;
                Transitions = new HashSet<ITransition>();
            }

            public void AddTransition(IState to, IPredicate condition)
            {
                Transitions.Add(new Transition(to, condition));
            }
        }
    }
}