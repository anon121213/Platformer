using System;
using System.Collections.Generic;
using FSM.States;

namespace FSM
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new ();
        private IExitableState _activeState;

        public void AddState(Type stateType, IExitableState state) =>
            _states.Add(stateType, state);

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}