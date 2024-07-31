using System;
using FiringRange.Code.Infrastructure.StateMachine.States;
using FiringRange.Code.Services;

namespace FiringRange.Code.Infrastructure.StateMachine.GameStateMachine
{
    public interface IGameStateMachine : IGlobalService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
        void AddState<TState>(TState instance) where TState : class, IState;
        void AddState<TState, TPayload>(TState instance) where TState : class, IPayloadedState<TPayload>;
        void AddState(Type type, IExitableState instance);
    }
}